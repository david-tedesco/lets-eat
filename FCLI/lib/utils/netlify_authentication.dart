import 'dart:convert';

import 'package:gotrue/gotrue.dart';
import 'package:http/http.dart' as http;

const NetlifyApiUrl = 'https://lets-eat-test.netlify.app/.netlify/identity';

class NetlifyAuthentication {
  Future<bool> netlifySignUp(List<String> args) async {
    const netlifyUrl = NetlifyApiUrl;

    final client = GoTrueClient(
      url: netlifyUrl,
    );

    final signUp = await client.signUp(
      args[0],
      args[1],
    );

    if (signUp.error == null) {
      print("User created with email ${args[0]}");
    } else {
      print("Error during ${args[0]} account creation");
      print("Error message = ${signUp.error}");
    }
    client.signOut();
    return true;
  }

  Future<bool> netlifyLogin(List<String> args) async {
    const netlifyUrl = NetlifyApiUrl;
    final client = GoTrueClient(url: netlifyUrl, headers: {
      "Access-Control-Allow-Origin": "*",
    });

    final login = await client.signIn(
      email: args[0],
      password: args[1],
    );

    if (login.error == null) {
      print("Logged in, user data  = ${login.data}");
    } else {
      print("Error to log user with email ${args[0]}");
      print("Error message = ${login.error?.message}");
      return false;
    }

    print("logged out");
    return true;
  }

  Future<bool> signOut() async {
    const netlifyUrl = NetlifyApiUrl;
    final client = GoTrueClient(
      url: netlifyUrl,
    );

    await client.signOut();
    return true;
  }

  bool passwordRecovery(String email) {
    const netlifyUrl = NetlifyApiUrl;
    final client = GoTrueClient(
      url: netlifyUrl,
    );

    //TODO: here manage password change

    return true;
  }

  // Posts a request to the netlifyApiUrl at the verify endpoint with the given token in the body.
  Future<bool> confirmUser(String token) async {
    const verifyUrl = '$NetlifyApiUrl/verify';
    final httpClient = http.Client();
    final response = await httpClient.post(Uri.parse(verifyUrl),
        body: json.encode({'token': token, 'type': 'signup'}));
    return (response.statusCode == 200);
  }
}
