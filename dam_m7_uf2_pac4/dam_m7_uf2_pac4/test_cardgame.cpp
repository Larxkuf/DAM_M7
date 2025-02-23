#include <gtest/gtest.h>
#include "cardgame.h"

// Prueba que draw_card() siempre retorna un valor entre 1 y 10
TEST(CardGameTest, DrawCardInRange) {
    for (int i = 0; i < 100; i++) {
        int card = draw_card();
        EXPECT_GE(card, 1);
        EXPECT_LE(card, 10);
    }
}

// Prueba para el caso en el que se acierta
TEST(CardGameTest, CheckGuessCorrect) {
    EXPECT_EQ(check_guess(5, 5), "Felicitats! Has encertat!");
}

// Prueba para el caso en el que se falla
TEST(CardGameTest, CheckGuessIncorrect) {
    EXPECT_EQ(check_guess(3, 7), "Has fallat! La carta era 7");
}

int main(int argc, char** argv) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}
