#include <ButtonSignalFilter.h>
#include <ArduinoRS485.h> // ArduinoModbus depends on the ArduinoRS485 library
#include <ArduinoModbus.h>

// COILS
#define led1  0
#define but1  1
#define but1on  200
#define but1off  201


// HOLDING REGISTERS
#define dim1  100

const int ledPin = 10;
const int butPin = 5;

ButtonSignalFilter b1(butPin);


void setup() {
  Serial.begin(9600);

  Serial.println("Modbus RTU Server LED");

  if (!ModbusRTUServer.begin(1, 9600)) {
    Serial.println("Failed to start Modbus RTU Server!");
    while (1);
  }

  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, LOW);

  ModbusRTUServer.configureCoils(0, 2);
  ModbusRTUServer.configureCoils(200, 2);
  ModbusRTUServer.configureHoldingRegisters(dim1, 1);
}

void loop() {
  ModbusRTUServer.poll();
  b1.Loop();

  int coi_L1 = ModbusRTUServer.coilRead(led1);
  int coil_B1_status = ModbusRTUServer.coilRead(but1);
  int coil_B1_on = ModbusRTUServer.coilRead(but1on);
  int coil_B1_off = ModbusRTUServer.coilRead(but1off);

  

}
