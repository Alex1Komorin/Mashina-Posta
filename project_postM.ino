//-----Экран-----
#include <GyverOLED.h> //библиотека для работы экрана
#include <charMap.h> //обвес GyverOLED
#include <icons_7x7.h> //обвес GyverOLED
#include <icons_8x8.h> //обвес GyverOLED
GyverOLED<SSD1306_128x64, OLED_NO_BUFFER> oled; //создаём экземпляр дисплея
//Массив, подержащий загрузочное изображение
const uint8_t START_SCREEN[] PROGMEM = {
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFC, 0xF8, 0xF0, 0xE0, 0xC0, 0xE0, 0xF0, 0xF8, 0xFC, 0xFC, 0x00, 0xB0, 0xB0, 0xB0, 0xB0, 0xB0, 0xF0, 0xF0, 0xE0, 0xF0, 0xF0, 0xF0, 0x00, 0xF0, 0xF0, 0xF0, 0x00, 0xF0, 0xF0, 0x00, 0xF0, 0xF0, 0xF0, 0x80, 0xC0, 0xC0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0x80, 0x80, 0x80, 0xF0, 0xF0, 0xF0, 0x00, 0xB0, 0xB0, 0xB0, 0xB0, 0xB0, 0xF0, 0xF0, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFC, 0xFC, 0xFC, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C, 0xFC, 0xFC, 0x00, 0xE0, 0xF0, 0xF0, 0x30, 0x30, 0xF0, 0xF0, 0xF0, 0x00, 0xE0, 0xF0, 0xF0, 0x30, 0x30, 0x30, 0x30, 0x30, 0x00, 0x30, 0x30, 0x30, 0xF0, 0xF0, 0xF0, 0x30, 0x30, 0x00, 0x00, 0xB0, 0xB0, 0xB0, 0xB0, 0xF0, 0xF0, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x3F, 0x1F, 0x03, 0x03, 0x03, 0x00, 0x3F, 0x3F, 0x3F, 0x0F, 0x1F, 0x1F, 0x19, 0x19, 0x19, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x18, 0x1F, 0x1F, 0x1F, 0x18, 0x1F, 0x1F, 0x00, 0x1F, 0x1F, 0x1F, 0x07, 0x07, 0x03, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x01, 0x01, 0x01, 0x1F, 0x1F, 0x1F, 0x0F, 0x1F, 0x1F, 0x19, 0x19, 0x19, 0x1F, 0x1F, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x1F, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x1F, 0x00, 0x0F, 0x1F, 0x1F, 0x18, 0x18, 0x1F, 0x1F, 0x1F, 0x00, 0x0F, 0x1F, 0x1F, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x1F, 0x1F, 0x00, 0x00, 0x00, 0x0F, 0x1F, 0x1F, 0x19, 0x19, 0x1F, 0x1F, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0xF8, 0xF8, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0xF8, 0xFC, 0xFC, 0xFC, 0xFC, 0xF8, 0xF0, 0xC0, 0x00, 0x38, 0xFC, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0xC0, 0xF0, 0xF8, 0xF8, 0xFC, 0x7C, 0x7C, 0xFC, 0xFC, 0xF8, 0xF0, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0, 0x00, 0x80, 0xE0, 0xF0, 0xF8, 0xFC, 0xFF, 0x7F, 0x3F, 0x1F, 0x07, 0x07, 0x07, 0x03, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0xF8, 0xF8, 0xFF, 0xFF, 0xFF, 0xFF, 0xF3, 0x00, 0x00, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0x3F, 0x3F, 0xFF, 0xFF, 0xFF, 0xF9, 0xF0, 0xE0, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x07, 0x07, 0x0F, 0x0F, 0x07, 0x07, 0x03, 0xF0, 0xFF, 0xFF, 0xFF, 0xFF, 0x3F, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x01, 0x03, 0x07, 0x1F, 0x3F, 0xFF, 0xFE, 0xFC, 0xF0, 0xE0, 0xE0, 0xE0, 0xC0, 0x80, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0xF8, 0xFF, 0xFF, 0xFF, 0x7F, 0x1F, 0x01, 0x80, 0x80, 0xE0, 0xE0, 0xF0, 0xF0, 0xF0, 0xE0, 0xE0, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x07, 0x0F, 0x07, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x0F, 0x1C, 0x1E, 0x1E, 0x1E, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1E, 0x0E, 0x00, 0x00, 0x00, 0x10, 0x1E, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x0F, 0x0F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x0F, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
};

//-----Кнопки-----
#include "GyverButton.h" //библиотека для работы с кнопками
//Кнопка сдвига каретки назад
#define BACK_MARK 12
//Кнопка установки/удаления метки на ленте
#define CHANGE_MARK_STATE 2
//Кнопка сдвига каретки вперёд
#define NEXT_MARK 13
GButton BTN_BACK(BACK_MARK); //экземпляр кнопки (сдвиг назад)
GButton BTN_CHANGE(CHANGE_MARK_STATE); //экземпляр кнопки (установки/удаления метки)
GButton BTN_NEXT(NEXT_MARK); //экземпляр кнопки (сдвиг вперёд)

//-----Регулярные выражения-----
#include "Regexp.h" //библиотека для работы с регулярными выражениями

//-----Адресная лента-----
#include <Adafruit_NeoPixel.h> //библиотека для работы с адресной лентой
//количество светодиодов
#define LED_COUNT 19
//пин, к которому подключена лента
#define LED_PIN 14
//Индекс в главном массиве - начало массива отрезка
#define RESET_START_LENA_POS 5000
//Длина основной ленты
#define G_LENTA_SIZE 10000
//максимальное число для индексирования
#define INT_MAX_VALUE 214748
//минимальное число для индексирования
#define INT_MIN_VALUE -214748
//минимальный задействованный в работе индекс
int MIN_INDEX = INT_MAX_VALUE; 
//максимальный задействованный в работе индекс
int MAX_INDEX = INT_MIN_VALUE;
//Адекватный индекс для пользователя
int real_pos = 0;
//Массив - Основная лента
bool LENTA[G_LENTA_SIZE];
//Массив - демонстрационный отрезок основной ленты
bool LENTA_SECTION[LED_COUNT];
//Текущая позиция начала отрезка в основном массиве
int CURRENT_START_LENTA_POSS = RESET_START_LENA_POS;
//Текущяя позиция каретки (неадекватная для пользователя)
int CURRENT_KARET_POSSITION = CURRENT_START_LENTA_POSS+(LED_COUNT/2);
//Позиция 0-го индекса на основной ленте
int REZ_KARET_SYSTEM_POS = CURRENT_KARET_POSSITION;
//Создаём экземпляр ленты
Adafruit_NeoPixel pix = Adafruit_NeoPixel(LED_COUNT, LED_PIN, NEO_GRB + NEO_KHZ800);
//Цвет меток
uint32_t MARK_COLOR = pix.Color(255, 0, 255); //цвет меток

//-----Индикация сдвигов-----
//Свтодиод-индиактор левого сдвига
#define LED_LEFT 1
//Свтодиод-индиактор правого сдвига
#define LED_RIGHT 0

//-----Связь по Wi-Fi-----
//·Выбираем библиотку для связи·
#ifdef ESP32
  #include <WiFi.h>
#else
  #include <ESP8266WiFi.h>
#endif
#include <WiFiUdp.h>
//·Указываем данные создаваемой точки доступа·
//Название точки доступа
const char* ssid = "PostM";
//Пароль от точки доступа
const char* password = "PasswordPostM";
//Заданный IP-адрес точки доступа
IPAddress ip(192, 168, 0, 109);
//Заданный порт точки доступа
unsigned int localPort = 8888;
//Переменная, хранящяя IP отправителя пакетов
IPAddress saveIP = WiFi.localIP();
//Буфер
char packetBuffer[UDP_TX_PACKET_MAX_SIZE + 1];
//Экземпляр класса WiFiUDP для связи по UDP
WiFiUDP Udp;
//строка, принимающая в себя команды
String val = ""; 
//длина строки val
int vall = 0; 

void setup()
{
  //-----Дисплей-----
  oled.init(); //инициализируем
  oled.autoPrintln(true); //включаем автоматический перенос символов
  start_screen_on_display(); //выводим стартовый экран

  //-----Кнопки-----
  //·Устанавливаем КД на нажатие·
  BTN_BACK.setDebounce(50);
  BTN_CHANGE.setDebounce(50);
  BTN_NEXT.setDebounce(50);
  //·Устаналиваем автоматическую проверку взаимодействия
  BTN_BACK.setTickMode(AUTO);
  BTN_NEXT.setTickMode(AUTO);

  //-----Лента-----
  pix.begin(); //инициализируем адресную ленту
  pix.setBrightness(50); //устанавливаем яркость
  pinMode(LED_PIN, OUTPUT); //пин ленты

  //-----Ком-порт-----
  Serial.begin(115200, SERIAL_8N1, SERIAL_FULL);

  //-----Связь по Wi-Fi-----
  WiFi.mode(WIFI_AP); //установка режима точки доступа
  WiFi.softAPConfig(ip, ip, IPAddress(255, 255, 255, 0)); //настройка IP-адресов
  WiFi.softAP(ssid, password); //создание точки доступа
  Udp.begin(localPort); //привязка порта к UDP
  saveIP = WiFi.localIP();
  
  //-----Индикация сдвигов-----
  pinMode(LED_RIGHT, OUTPUT); //пин светодиода правого сдвига
  pinMode(LED_LEFT, OUTPUT); //пин светодиода левого сдвига
  
  //Задержка (для того, чтобы стартовый экран немного повисел на экране)
  delay(2500);
  //Вывод текущего индекса на экран
  index_on_display();
}

//вывод старотого экрана
void start_screen_on_display()
{
    oled.clear(); //очищаем дисплей
    oled.drawBitmap(0, 0, START_SCREEN, 128, 64); //отрисовываем картинку
    oled.setCursor(30, 7); //устаналиваем курсор для печати
    oled.setScale(1); //устанавливаем размер текста
    oled.print("Коллектив 12"); //указываем наименование коллектива
}

//Выводит на экран результат выполнения
void draw_user_message(bool status, const char* text)
{
    oled.clear(); //очищаем экран
    oled.setScale(2); //устаналиваем размер текста
    oled.setCursorXY(30, 0); //устаналиваем курсор по координатам
    if(!status) //если операция завершилась неуспешно
      oled.print("Ошибка"); //устаналиваем заголовок
    else //если операция завершилась успешно
      oled.print("Успех"); //устаналиваем заголовок
    oled.setCursor(0, 3); //устанавливаем курсор
    oled.setScale(1); //устанавливаем размер
    oled.print(text);  //печатаем указанное сообщение
    oled.setCursor(0, 7); //устанавливаем курсор
    oled.print("Нажмите любую кнопку..."); //выводим подсказку
}

//Вывод индекса на экран
void index_on_display()
{
  oled.clear(); //очищаем экран
  oled.setScale(2); //устаналиваем размер шрифта
  oled.setCursorXY(30, 0); //устанавливаем курсор по координатам
  oled.print("ИНДЕКС"); //рисуем заголовок
  
  int real_pos_len = String(real_pos).length(); //узаём длину индекса 
  int shift = 0; //сооздаём переменную для хранения отступа
  //выбираем нужный размер отступа в соответствии с количеством символов в индексе
  switch(real_pos_len)
  {
    case 1: {shift = 50; break;}
    case 2: {shift = 40; break;}
    case 3: {shift = 30; break;}
    case 4: {shift = 20; break;}
    default: {shift = 0; break;}
  }
    oled.setScale(4); //устаналиваем размер шрифта
    oled.setCursorXY(shift, 18); //устанавливаем позицию курсора
    oled.print(real_pos); //выводим индекс на экран
}

//Возвращает каретку на указанный пользовательский индекс (без указания - на 0-й)
bool go_to_index(int index = 0)
{
  //проверяем на выход за пределы
  if ((index > G_LENTA_SIZE-1) || (index < (RESET_START_LENA_POS - G_LENTA_SIZE)))
    return false; //завершаем операцию неудачей
  //устанавливаем новое начало демонстрационного отрезка
  CURRENT_START_LENTA_POSS = RESET_START_LENA_POS+index;
  //устанавливаем системную поицию каретки на нужную позицию
  CURRENT_KARET_POSSITION = CURRENT_START_LENTA_POSS+(LED_COUNT/2); 
  copy_mass(); //перерисовываем ленту
  real_pos = index; //устанавливаем пользовательский индекс на требуемый
  index_on_display(); //выводим новый индекс на дисплей
  return true; //успешно завершаем операцию
}

//Удаление всех меток с ленты
void del_all()
{
  //сбрасываем пределы активной области
  MIN_INDEX = INT_MAX_VALUE;
  MAX_INDEX = INT_MIN_VALUE;
  //очищаем массивы
  memset(LENTA_SECTION, 0, sizeof(LENTA_SECTION));
  memset(LENTA, 0, sizeof(LENTA));
  //перерисовываем ленту
  copy_mass();
}

//Копирует из основного массива отрезок в демонстрационное окно (отрисовка ленты)
void copy_mass()
{
  for (int i = 0; i < LED_COUNT;i++) //проходим по всему демонстрационному отрезку
  {
    //получаем элемент из основной ленты на нужной позиции
    LENTA_SECTION[i] = LENTA[CURRENT_START_LENTA_POSS+i];
    if (LENTA_SECTION[i] == true) //если имеется метка на основной ленте
    {
      pix.setPixelColor(i, MARK_COLOR); //зажигаем светодиод на отрезке
    }
    else //если метки на данной позиции в основной ленте нет
    {
      pix.setPixelColor(i, pix.Color(0, 0, 0)); //гасим светодиод на отрезке
    }
  }
  pix.show(); //применяем изменения к ленте (перерисовка)
}

//Формирование индексов рабочей области
void set_min_max_index()
{
   //сравниваем минимальный индекс с текущим
  	MIN_INDEX = min(MIN_INDEX, CURRENT_KARET_POSSITION);
    //сравниваем максимальный индекс с текущим
    MAX_INDEX = max(MAX_INDEX, CURRENT_KARET_POSSITION); 
}

//Сдвиг индекса вперёд
bool to_next(bool silent = false)
{
  set_min_max_index(); //редактируем рабочую область
  //проверяем на выход за пределы ленты
  if (CURRENT_START_LENTA_POSS + LED_COUNT + 1 > G_LENTA_SIZE) 
    return false; //завершаем операцию неуспехом
  real_pos++; //увеличиваем пользовательский индекс
  //увеличиваем позицию начала демонстрационного отрезка
  CURRENT_START_LENTA_POSS++; 
  //определяем текущую системную позицию каретки
  CURRENT_KARET_POSSITION = CURRENT_START_LENTA_POSS+(LED_COUNT/2);
  if (!silent) //если функция выполняется не в тихом режиме
  {
    digitalWrite(LED_RIGHT, HIGH); //зажигаем индикационный светодид
    copy_mass(); //перерисовываем ленту
    delay(50); //задержка для светодиода
    digitalWrite(LED_RIGHT, LOW); //гасим индикационный светодиод
    index_on_display(); //выводим новый индекс на экран
  }
  return true; //завершаем операцию успехом
}

//Сдвиг индекса назад 
bool to_back(bool silent = false)
{
  set_min_max_index(); //редактируем рабочую область
  if (CURRENT_START_LENTA_POSS < 0) //проверяем на выход за пределы ленты
  return false; //завершаем операцию неуспехом
  real_pos--; //уменьшаем пользовательский индекс
  CURRENT_START_LENTA_POSS--; //уменьшаем позицию начала демонстрационного отрезка
  //определяем текущую системную позицию каретки
  CURRENT_KARET_POSSITION = CURRENT_START_LENTA_POSS+(LED_COUNT/2);
  if(!silent) //если функция выполняется не в тихом режиме
  {
    digitalWrite(LED_LEFT, HIGH); //зажигаем индикационный светодид
    copy_mass(); //перерисовываем ленту
    delay(50); //задержка для светодиода
    digitalWrite(LED_LEFT, LOW); //гасим индикационный светодиод
    index_on_display(); //выводим новый индекс на экран
  }
  return true; //завершаем операцию успехом
}

//Условный оператор
bool if_mark()
{
    //если метка установлена на ленте на текущей позиции
    if (LENTA[CURRENT_KARET_POSSITION] == true)
    {
      	return true; //возвращаем истину
    }
  	else //если метка не установлена на ленте на текущей позиции
    {
      return false; //возвращаем ложь
    }
}

//Установка метки
bool set_mark(bool silent = false)
{
  	set_min_max_index(); //редактируем рабочую область
  	if (if_mark()) //если метка установлена
    {
      	return false; //завершаем операцию неудачей
    }
  	LENTA[CURRENT_KARET_POSSITION] = true; //устаналиваем метку на ленту
  	if (!silent) //если не техий режим
  		copy_mass(); //перерисовываем ленту
    return true; //успешно завершаем операцию
}

//Удаление метки
bool del_mark(bool silent = false)
{
	  set_min_max_index(); //редактируем рабочую область
  	if (!if_mark()) //если метка не установлена
    {
      	return false; //завершаем операцию неудачей
    }
  	LENTA[CURRENT_KARET_POSSITION] = false; //удаляем метку с ленты
  	if (!silent) //если не техий режим
      copy_mass(); //перерисовываем ленту
    return true; //успешно завершаем операцию
}

//Изменение состояния метки
void change_mark_state()
{
  if (!if_mark()) //если метка не установлена
  {
     	set_mark(); //устаналиваем метку
  }
  else //в ином случае
  {
      del_mark(); //удаляем меткку
  }
}

//Проверка на соответствие регулярке
bool check_on_input_massiv(const char* text, int len)
{
  MatchState ms; //объявляем экземпляр MatchState
  char testString[len]; //создаём массив символов заданной длины
  strcpy(testString, text); //копируем в массив
  char regularExpression[] = "[01]+%s[%d]+"; //формируем регулярное выражение
  ms.Target(testString); //задаём текст для сравнения с регуляркой
  int result = ms.Match(regularExpression); //получаем количество совпадений с регуляркой
  if(result == 1) //если найдено одно совпадение
  {
    return true; //возвращаем истину
  }
  else //в ином случае
  {
    return false; //возвращаем ложь
  }
}

//Установка заданного массива на ленту
bool task_install_in_mass(String str, int len)
{
  go_to_index(); //устанавливаем каретку на 0 индекс
  del_all(); //полностью очищаем ленту ленты
  bool SPLIT_SPACE = false; //состояние поиска разделителя
  String TEMP_SET_INDEX = ""; //переменная для хранения индекса
  for(int i = 0; i < len; i++) //идём по всей строке
  {
    if (!SPLIT_SPACE) //если не разделитель
    {
      if(str[i] == '0') //если ячейка строки-ленты пуста
      {
        to_next(true); //сдвиагемся на следующий индекс в тихом режиме
      }
      else if(str[i] == '1') //если ячейка строки-ленты содержит метку
      {
        set_mark(true); //устанавливаем метку на ленту в тихом режиме
        to_next(true); //сдвигаемся на следующий индекс в тихом режиме
      }
      else //если символ строки не является состоянием для ячейки
      {
        SPLIT_SPACE = true; //устанавливаем, что нашли разделитель
      }
    }
    else //если разделитель уже найден
    {
      TEMP_SET_INDEX += str[i]; //формируем индекс из строки
    }
  }
  if (go_to_index(TEMP_SET_INDEX.toInt())) //если получилось перейти на нужный индекс
    return true; //завершаем операцию успехом
  else
    return false; //завершаем операцию неудачей
  
}

//Получение результата с ленты
bool get_result()
{
    //если рабочая область не выстроена
    if (MAX_INDEX < (G_LENTA_SIZE*(-1)) || MIN_INDEX > G_LENTA_SIZE)
    {
      send("!J"); //сообщаем об ошибке
      return false; //завершаем операцию неуспешно
    }
    String s; //объявляем строковую переменную для формирования результата
    for (int i = MIN_INDEX; i <= MAX_INDEX; i++) //проходимся по рабочей области
    {
      if (LENTA[i] == false) //если метки нет
      	s += "0"; //добавляем к строке 0
      else //в ином случае
        s += "1"; //добавляем к строке 1
    }
    int startIndex = s.indexOf("1"); //находим первое вхождение 1
    int endIndex = s.lastIndexOf("1"); //находим последнее вхождение 1
    if (startIndex == -1) //если нет вхождений 1
    {
      send("#J 0"); //сообщаем о том, что область пуста
      return true; //успешно завершаем операцию
    }
    //формируем ответ в виде рабочей области
    String output = "#J " + s.substring(startIndex, endIndex + 1);
    char charArray[output.length() + 1]; //создаём массив символов
    output.toCharArray(charArray, sizeof(charArray)); //переводим строку в массив
    send(charArray); //отправляем рабочую область Android'у
    return true; //успешно завершаем операцию
}

//Отправка ответа
void send(const char* text)
{
    //начинаем отправку пакета с указанием IP и порта отправителя
    Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
    //указываем текст для отправки
    Udp.write(text);
    //завершаем отправку пакета
    Udp.endPacket();
}

//Поиск вхождений символа в строке
int count_entrance(String text, char character)
{
  int count = 0; //счётчик

  for (int i = 0; i < text.length(); i++) //проходимся по строке
  {
    if (text.charAt(i) == character) //если нашли заданный символ
    {
      count++; //увеличиваем счётчик
    }
  }
  return count; //возвращаем количество вхождений символа
}

//Преобразование строки в массив
void str_to_mass(String* array, String str, String delimiter)
{
  int index = 0; //индекс
  // Разбиваем строку на элементы с использованием разделителя
  int startPos = 0; //начальная позиция
  int endPos = str.indexOf(delimiter); //конечная позиция
  while (endPos != -1) //пока не кончатся разделители
  {
    array[index] = str.substring(startPos, endPos); //вносим слово до разделителя в массив
    startPos = endPos + 1; //смещаем начальную позицию
    endPos = str.indexOf(delimiter, startPos); //ищем следующее вхождение разделителя
    index++; //смещаем индекс
  }
  //вносим слово после последнего разделителя в массив
  array[index] = str.substring(startPos);
}

//Выполняет алгоритм (mode: false - свободный режим, true - квест-задания)
void doing_alg(String str, bool mode)
{
  String beforeAmpersand = ""; //часть до разделителя (команды)
  String afterAmpersand = ""; //часть после после разделителя (переходы)
  int ampersandIndex = str.indexOf("&"); //находим вхождение разделителя
  if (ampersandIndex != -1) //если разделитель найден
  {
      //часть до разделителя (команды)
      beforeAmpersand = str.substring(0, ampersandIndex);
      //часть после после разделителя (переходы)
      afterAmpersand = str.substring(ampersandIndex + 1);
  }
  else //в ином случае
  {
      if (!mode) send("!P"); //возвращаем ошибку для свободного режиме
      else send("!J"); //возвращаем ошибку для режима квест-заданий
      return; //выходим из метода
  }
  //количество команд  
  int COUNT_COMANDS = count_entrance(beforeAmpersand,';') + 1;
  //количество переходов
  int COUNT_TRANSITION = count_entrance(afterAmpersand,';') + 1;
  //если количество команд не совпало с количеством переходов
  if (COUNT_COMANDS != COUNT_TRANSITION) 
  {
      if (!mode) send("!P"); //возвращаем ошибку для свободного режиме
      else send("!J"); //возвращаем ошибку для режима квест-заданий
      return; //выходим из метода
  } 
  String COMANDS[COUNT_COMANDS]; //массив из команд
  String TRANSITION[COUNT_TRANSITION]; //массив из переходов
  String delimiter = ";"; //разделитель
  str_to_mass(COMANDS, beforeAmpersand, delimiter); //преобразуем строку команд в массив
  str_to_mass(TRANSITION, afterAmpersand, delimiter); //преобразуем строку переходов в массив
  if (!mode) send("#P"); //сообщаем Android'у об успешной обработке принятного алгоритма
  int index = 0;
  while(true)
  {
    BTN_CHANGE.tick(); //отслеживаем нажатие кнопки установки/удаления метки
    connect_processing(); //проверяем, нет ли UDP пакетов
    if (vall > 0) //если есть пакет
      send("!A"); //сообщаем, что работает алгоритм
    if(BTN_CHANGE.isStep()) //если кнопка установки/удаления метки зажата
    {
      //сообщаем пользователю через экран о ручном завершении выполнения
      draw_user_message(true, "Ручное завершение алгоритма произошло успешно!");
      //выходим из цикла (выполнения)
      break;
    } 
    bool if_result; //содержит результат условного оператора
    bool if_using = false; //индиактор использования условного оператора
    if(COMANDS[index] == "1") //если команда установки метки
    {
      if(!set_mark()) //еслм установить метку не полуилось
      {
        //сообщаем Android'у об ошибке работы алгоритма
        if (mode) send("#JJ"); 
        //сообщаем пользователю через экран о произошедшей ошибке
        draw_user_message(false, "Была совершена попытка повторно поставить метку.");
        //выходим из цикла (выполнения)
        break;
      } 
    }
    else if(COMANDS[index] == "0") //если команда удаления метки
    {
      if(!del_mark()) //если не удалось удалить метку
      {
        //сообщаем Android'у об ошибке работы алгоритма
        if (mode) send("#JJ"); 
        //сообщаем пользователю через экран о произошедшей ошибке
        draw_user_message(false, "Была совершена попытка повторно удалить метку.");
        //выходим из цикла (выполнения)
        break;
      }
    }
    else if(COMANDS[index] == ">") //если команда свдига вправо
    {
      //если не удалось сместиться
      if(!to_next()) 
      {
        //сообщаем Android'у об ошибке работы алгоритма
        if (mode) send("#JJ"); 
        //сообщаем пользователю через экран о произошедшей ошибке
        draw_user_message(false, "Произошёл выход за пределы ленты.");
        //выходим из цикла (выполнения)
        break;
      }
    }
    else if(COMANDS[index] == "<") ////если команда свдига влево
    {
      //если не удалось сместиться
      if(!to_back())
      {
        //сообщаем Android'у об ошибке работы алгоритма
        if (mode) send("#JJ"); 
        //сообщаем пользователю через экран о произошедшей ошибке
        draw_user_message(false, "Произошёл выход за пределы ленты.");
        //выходим из цикла (выполнения)
        break;
      }
    }

    else if(COMANDS[index] == "?") //если команда условного оператора
    {
      if_result = if_mark(); //присваиваем результат перменной
      if_using = true; //взводим индиактор условного оператора
    } 
    else if(COMANDS[index] == ".") //если команда остановки алгоритма
    {
      //отправляем результат с рабочей области
      get_result();
      //сообщаем пользователю через экран об успешном завершении работы алгоритма
      draw_user_message(true, "Выполнение алгоритма завершилось успешно!");
      //выходим из цикла (выполнения)
      break;
    }
    else if(COMANDS[index] == "%") //если команда - пустая строка
    {
      //сообщаем Android'у об ошибке работы алгоритма
      if (mode) send("#JJ"); 
      //сообщаем пользователю через экран о произошедшей ошибке
      draw_user_message(false, "Был совершён переход на пустую команду.");
      //выходим из цикла (выполнения)
      break;
    }
    else
    {
      //сообщаем Android'у об ошибке работы алгоритма
      if (mode) send("#JJ"); 
      //сообщаем пользователю через экран о произошедшей ошибке
      draw_user_message(false, "Произошла неизвестная ошибка.");
      //выходим из цикла (выполнения)
      break;
    }
    //вхождение условного разделителя в переходе
    int sleshIndex = TRANSITION[index].indexOf("/");
    //если вхождение условного разделителя найдено
    if(sleshIndex != -1)
    { 
      //переход до разделителя (строка)
      beforeAmpersand = TRANSITION[index].substring(0, sleshIndex);
      //переход после разделителя (строка)
      afterAmpersand = TRANSITION[index].substring(sleshIndex + 1);
      //если условный оператор дал положительный результат, берём часть до разделителя
      if(if_result) index = afterAmpersand.toInt();
      //в ином случае - после разделителя
      else index = beforeAmpersand.toInt();
    }
    else //если условный разделитель не найден
    {
      //присваиваем переменной index следующий переход
      index = TRANSITION[index].toInt();
    }
    //если index 
    if (index == -2)
    {
      //отправляем результат с рабочей области
      get_result();
      //сообщаем пользователю через экран об успешном завершении работы алгоритма
      draw_user_message(true, "Выполнение алгоритма завершилось успешно!");
      //выходим из цикла (выполнения)
      break;
    }
    delay(400); //задержка между выполнением команд
  }
}

//Работа с сетевыми пакетами
void connect_processing()
{
  val = ""; //очищаем строку
  vall = 0; //обнуляем счётчик символов строки
  int packetSize = Udp.parsePacket(); //получаем размер пакета
  if (packetSize) //если пакет не пустой
  {
    saveIP = Udp.remoteIP(); //сохраняем IP отправителя
    int n = Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE); //читаем пакет в буфер
    packetBuffer[n] = 0; //устанавливаем конечный 0-й байт
    val = String(packetBuffer); //сохраняем пакет из буфера в строку
    vall = val.length(); //получаем размер строки
    if (val == "C") //обрабтка проверки связи со стороны Android'а
    {
      send("#C"); //сообщаем о наличии подключения
    }
  }
}
void loop()
{
    //-----Работа с кнопками-----
    BTN_CHANGE.tick(); //опрос кнопки установки/удаления метки
    //если одновременно удерживаются кнопки сдвига вперёд и установки/удаления метки
    if(BTN_NEXT.isStep() && BTN_CHANGE.isStep()) 
    {
      del_all(); //удаляем все метки с ленты
    } 
    if(BTN_CHANGE.isClick()) //если нажата кнопка установки/удаления метки
    {
      change_mark_state(); //устаналиваем/удаляем метку 
    }
    if(BTN_NEXT.isClick()) //если нажата кнопка сдвига ленты вперёд
    {
      to_next(); //сдвигаемся на следующий индекс
    }
    if(BTN_BACK.isClick()) //если нажата кнопка сдвига ленты назад
    {
      to_back(); //сдвигаемся на предыдущий индекс
    }
    //если одновременно удерживаются кнопки сдвига назад и установки/удаления метки
    if(BTN_BACK.isStep() && BTN_CHANGE.isStep()) 
    {
      go_to_index(); //возвращаемся на 0-й индекс
    } 
    
    //проверка наличия UDP пакетов на входе
    connect_processing();

    //-----Обработка команд-----
    if (vall > 1) //если принятая команда больше 1-го символа
    {
      char charArray[vall + 1]; // +1 для хранения символа конца строки '\0'
      val.toCharArray(charArray, sizeof(charArray)); //переводим строку в массив символов
      if (charArray[0] == 'P') //если получена команда, начинающаяся на P
      {
        doing_alg(val.substring(2, val.length()), false); //запускаем алгоритм
      }
      else if (charArray[0] == 'J') //если получена команда, начинающаяся на J
      {
        //запускам алгоритм в режиме квест-заданий
        doing_alg(val.substring(2, val.length()), true); 
      }
      //проверяем полученную строку на попытку задать массив на ленту
      else if (check_on_input_massiv(charArray, vall + 1)) 
      {
      if(task_install_in_mass(val, vall)) //устаналиваем массив на ленту
        send("#^"); //отправляем подтверждение Android'у
        else
          send("!^"); //отправляем Android'у сообщение о неуспешности проведённой операции
      }
    }
}
  	

  