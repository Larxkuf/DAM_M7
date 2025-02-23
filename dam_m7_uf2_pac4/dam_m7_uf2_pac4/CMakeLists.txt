cmake_minimum_required(VERSION 3.16)
project(CardGameProject)

set(CMAKE_CXX_STANDARD 17)

# Agregar Google Test
add_subdirectory(googletest)
include_directories(${gtest_SOURCE_DIR}/include ${gtest_SOURCE_DIR})
include_directories(${CMAKE_CURRENT_SOURCE_DIR})

# Ejecutable del juego (compila cardgame.cpp con su main)
add_executable(game_exec cardgame.cpp)

# Ejecutable de pruebas unitarias (se define la macro UNIT_TEST para evitar compilar el main del juego)
add_executable(runTests test_cardgame.cpp cardgame.cpp)
target_compile_definitions(runTests PRIVATE UNIT_TEST)
target_link_libraries(runTests gtest gtest_main)
