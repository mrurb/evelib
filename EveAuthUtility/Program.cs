﻿using System;
using eZet.EveLib.EveAuthModule;

namespace eZet.EveLib.EveAuthUtility {
    public class EveAuthUtility {

        static public EveAuth Auth = new EveAuth();
        static void Main(string[] args) {
            Console.WriteLine("Tool for obtaining access and refresh tokens from the Eve Online SSO.");
            Console.WriteLine("No information is stored, some data is exchanged with Eve SSO.");
            Console.WriteLine("The sourcecode is available here: https://github.com/ezet/evelib");
            Console.WriteLine("You need to register an application at https://developers.eveonline.com, \nthe callback URL can be set to '/'.");
            Console.WriteLine("Your client ID and secret key will be provided by \nhttps://developers.eveonline.com after registering an application.\n");
            Console.Write("Enter your client ID: ");
            string clientId = Console.ReadLine();
            //string clientId = "46daa2b378bd4bc189df4c3a73af226a";
            Console.Write("Enter your secret key: ");
            string secret = Console.ReadLine();
            //string secret = "K8GcWADljgnLZyrKGFfiqzHVvViGhapOYSCEy83h";
            string encodedKey = EveAuth.Encode(clientId, secret);
            //Console.WriteLine("Encoded key: " + encodedKey);
            string authLink = Auth.CreateAuthLink(clientId, "/", CrestScope.PublicData);
            Console.WriteLine("Please log in using the following link");
            Console.WriteLine(authLink);
            Console.WriteLine("After logging in, copy the full URL from your browser.");
            Console.WriteLine("Enter the full URL after logging in: ");
            string url = Console.ReadLine();
            string authCode = "";
            try {
                int start = url.IndexOf("?code=", System.StringComparison.Ordinal);
                int end = url.IndexOf("&state", System.StringComparison.Ordinal);
                authCode = url.Substring(start + 6, end - start - 6);
            } catch (Exception) {
                Console.WriteLine("Unable to locate authentication code, please try again.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Authentication code found: " + authCode);
            Console.WriteLine("Authenticating...");
            AuthResponse response;
            try {
                response = Auth.AuthenticateAsync(encodedKey, authCode).Result;
            } catch (Exception) {
                Console.WriteLine("Authentication unsuccessfull, please try again.");
                return;
            }
            Console.WriteLine("Authentication successfull!");
            Console.WriteLine("Access token: " + response.AccessToken);
            Console.WriteLine("Refresh token: " + response.RefreshToken);
            Console.ReadKey();
        }
    }
}