#include <iostream>
#include <fstream>
#include <chrono>
#include <ctime>

int main() {
    std::cout << "Hola, món!" << std::endl;

    auto now = std::chrono::system_clock::now();
    std::time_t now_time = std::chrono::system_clock::to_time_t(now);

    char timeBuffer[26];
#ifdef _WIN32
    ctime_s(timeBuffer, sizeof(timeBuffer), &now_time);
#else
    std::strftime(timeBuffer, sizeof(timeBuffer), "%c", std::localtime(&now_time));
#endif

    std::ofstream logFile("log.txt", std::ios::app);
    if (logFile.is_open()) {
        logFile << "Execució: " << timeBuffer << std::endl;
        logFile.close();
    }
    else {
        std::cerr << "Error en obrir el fitxer log.txt" << std::endl;
    }

    return 0;
}
