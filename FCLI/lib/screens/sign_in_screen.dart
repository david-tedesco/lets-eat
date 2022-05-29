import 'package:flutter/material.dart';
import 'package:lets_eat/res/custom_colors.dart';
import 'package:lets_eat/utils/google_authentication.dart';
import 'package:lets_eat/widgets/google_sign_in_button.dart';
import 'package:lets_eat/utils/netlify_authentication.dart';
import 'package:lets_eat/screens/user_info_screen.dart';
import 'package:lets_eat/screens/sign_up_screen.dart';

class SignInScreen extends StatefulWidget {
  String _confirmationToken;
  SignInScreen({String? confirmationToken, Key? key})
      : _confirmationToken = confirmationToken ?? '',
        super(key: key);

  @override
  _SignInScreenState createState() => _SignInScreenState();
}

class _SignInScreenState extends State<SignInScreen> {
  final passwordController = TextEditingController();
  final emailController = TextEditingController();
  final auth = NetlifyAuthentication();

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
  Widget build(BuildContext context) {
    if (widget._confirmationToken.isNotEmpty) {
      auth.confirmUser(widget._confirmationToken).then((value) {
        if (value) {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(
                content: Text(
                    'Votre email a été validé ! Vous pouvez maintenant vous connecter.')),
          );
        } else {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(
                content: Text(
                    'Une erreur est survenue lors de la confirmation de votre email.')),
          );
        }
      });
    }
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
                      'Authentication',
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
                          return 'Veuillez entrer votre email';
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
                    ElevatedButton(
                      onPressed: () async {
                        if (1 == 1) {
                          //TODO: add here check login data
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(
                                content: Text('Connexion en cours...')),
                          );
                          var args = [
                            emailController.text,
                            passwordController.text
                          ];
                          var resLogin = await auth.netlifyLogin(args);
                          print("res login = $resLogin");
                          var user;
                          if (resLogin == true) {
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                  content: Text('Connexion réussie !')),
                            );
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
                                  content: Text('Une erreur est survenue.')),
                            );
                          }
                        }
                      },
                      child: const Text('Se connecter'),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        Navigator.of(context).pushReplacement(
                          MaterialPageRoute(
                            builder: (context) => SignUpScreen(),
                          ),
                        );
                      },
                      child: const Text('Créer un compte'),
                    ),
                  ],
                ),
              ),
              FutureBuilder(
                future:
                    GoogleAuthentication.initializeFirebase(context: context),
                builder: (context, snapshot) {
                  if (snapshot.hasError) {
                    return Text('Error initializing Firebase');
                  } else if (snapshot.connectionState == ConnectionState.done) {
                    return GoogleSignInButton();
                  }
                  return CircularProgressIndicator(
                    valueColor: AlwaysStoppedAnimation<Color>(
                      CustomColors.firebaseOrange,
                    ),
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
