import 'package:flutter/material.dart';
import 'package:lets_eat/utils/netlify_authentication.dart';

import 'screens/sign_in_screen.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var confirmationToken = "";
    print(Uri.base);
    if (Uri.base.fragment.contains('confirmation_token')) {
      confirmationToken = Uri.base.fragment.split('=')[1];
      print(confirmationToken);
    }
    return MaterialApp(
      title: 'Let\'s Eat!',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.indigo,
        brightness: Brightness.dark,
      ),
      home: SignInScreen(confirmationToken: confirmationToken),
    );
  }
}
