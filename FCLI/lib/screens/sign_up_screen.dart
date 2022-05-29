import 'package:flutter/material.dart';
import 'package:lets_eat/res/custom_colors.dart';
import 'package:lets_eat/utils/google_authentication.dart';
import 'package:lets_eat/widgets/google_sign_in_button.dart';
import 'package:lets_eat/utils/netlify_authentication.dart';
import 'package:lets_eat/screens/user_info_screen.dart';
import 'package:lets_eat/screens/sign_in_screen.dart';

class SignUpScreen extends StatefulWidget {
  @override
  _SignUpScreenState createState() => _SignUpScreenState();
}

class _SignUpScreenState extends State<SignUpScreen> {
  final passwordController = TextEditingController();
  final passwordConfirmController = TextEditingController();
  final emailController = TextEditingController();

  @override
  void disposeEmail() {
    emailController.dispose();
    super.dispose();
  }

  @override
  void disposePassword() {
    passwordController.dispose();
    super.dispose();
  }

  @override
  void disposeConfirmPassword() {
    passwordConfirmController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: CustomColors.firebaseNavy,
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.only(
            left: 16.0,
            right: 16.0,
            bottom: 20.0,
          ),
          child: Column(
            mainAxisSize: MainAxisSize.max,
            children: [
              Row(),
              Expanded(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Flexible(
                      flex: 1,
                      child: Image.asset(
                        'assets/lets_eat_logo.png',
                        height: 160,
                      ),
                    ),
                    SizedBox(height: 20),
                    Text(
                      'Register',
                      style: TextStyle(
                        color: CustomColors.firebaseYellow,
                        fontSize: 40,
                      ),
                    ),
                    TextFormField(
                      decoration: const InputDecoration(
                          border: UnderlineInputBorder(), labelText: 'Email'),
                      controller: emailController,
                      validator: (value) {
                        //TODO: check if it's email address
                        if (value == null || value.isEmpty) {
                          return 'Veuillez entrer votre adresse email';
                        }
                        return null;
                      },
                    ),
                    TextFormField(
                      decoration: const InputDecoration(
                          border: UnderlineInputBorder(),
                          labelText: 'Mot de passe'),
                      obscureText: true,
                      controller: passwordController,
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Veuillez entrer votre mot de passe';
                        }
                        return null;
                      },
                    ),
                    TextFormField(
                      decoration: const InputDecoration(
                          border: UnderlineInputBorder(),
                          labelText: 'Confirmer le mot de passe'),
                      obscureText: true,
                      controller: passwordConfirmController,
                      validator: (value) {
                        if (value == null ||
                            value.isEmpty ||
                            value != passwordController.text) {
                          return 'Les mot de passe ne correspondent pas';
                        }
                        return null;
                      },
                    ),
                    ElevatedButton(
                      onPressed: () async {
                        if (1 == 1) {
                          //TODO: add here check login data
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(
                                content: Text('Inscription en cours')),
                          );
                          var auth = NetlifyAuthentication();
                          var args = [
                            emailController.text,
                            passwordController.text
                          ];
                          var resLogin = await auth.netlifySignUp(args);
                          print("res register = $resLogin");
                          var user;
                          if (resLogin == true) {
                            Navigator.of(context).pushReplacement(
                              MaterialPageRoute(
                                builder: (context) => UserInfoScreen(
                                  user: user,
                                ),
                              ),
                            );
                          } else {
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                  content:
                                      Text('Erreur lors de l\'inscription')),
                            );
                          }
                        }
                      },
                      child: const Text('Créer un compte'),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        Navigator.of(context).pushReplacement(
                          MaterialPageRoute(
                            builder: (context) => SignInScreen(),
                          ),
                        );
                      },
                      child: const Text('Se connecter'),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
