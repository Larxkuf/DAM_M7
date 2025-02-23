#include <iostream>
#include <cstdlib>
#include <ctime>
#include <string>
#include <limits>
#include "cardgame.h"

using namespace std;

int draw_card() {
    return rand() % 10 + 1;
}

string check_guess(int user_guess, int card) {
    if (user_guess == card) {
        return "Felicitats! Has encertat!";
    }
    else {
        return "Has fallat! La carta era " + to_string(card);
    }
}

#ifndef UNIT_TEST  
int main() {
    srand(time(0)); 
    int user_guess;

    cout << "Benvingut al joc de les cartes!" << endl;

    while (true) {
        cout << "Tria un número entre 1 i 10 (o 0 per sortir): ";
        cin >> user_guess;

        if (cin.fail()) { // if si el user introduce algo inválido 
            cin.clear(); 
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // descarta lo introducido, y
            cout << "Entrada no vàlida. Torna-ho a intentar.\n"; //mensaje de error, y
            continue;  //vuelve a pedir un número
        }


        if (user_guess == 0) {
            cout << "Sortint del joc...\n";
            break;
        }

        if (user_guess < 1 || user_guess > 10) {
            cout << "Número fora de rang, torna a intrduïr-ne un. Ha de ser entre 1 i 10.\n";
            continue;
        }

        int card = draw_card();
        cout << check_guess(user_guess, card) << endl;
    }

    return 0;
}
#endif
