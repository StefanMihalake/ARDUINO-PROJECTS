#include <ArduinoModbus.h>
#include <StefanMLibrery.h>
#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
 #include <avr/power.h> 
#endif
// BUTTONS
const int bPin1 = 5;
const int bPin2 = 6;
const int bPin3 = 7;
// LEDS
const int led1 = 8;
const int led2 = 9;
const int led3 = 10;
// LEDSTRIP
const int ledStrip = 11;
int numpixel = 30;
//  MODBUS ADDRESSES
int _startCoil = 100;
int _startHReg = 200;
int _startIReg = 100;
int _startDIReg = 100;


Dimmer butLed1(13, bPin1, led1, 25, 255, 1500, 250);
Dimmer butLed2(52, bPin2, led2, 25, 255, 1500, 250);
Dimmer butLed3(52, bPin3, led3, 25, 255, 1500, 250);

Adafruit_NeoPixel pixels(numpixel, ledStrip, NEO_GRB + NEO_KHZ800);

// DIMMERS ARRAY
Dimmer dimmers[] = {butLed1, butLed2, butLed3};

int ledNum = sizeof(dimmers) / sizeof(dimmers[0]);
int pixelWriteIndex;
int pixelReadIndex;




void setup() {
  //Serial.begin(9600);
  if (!ModbusRTUServer.begin(1, 9600))
  {
    Serial.println("Failed to start Modbus RTU Server!");
    while (1);
  }
  // CONFIGURE MODBUS
  ModbusRTUServer.configureCoils(_startCoil, ledNum * 2);
  ModbusRTUServer.configureHoldingRegisters(_startHReg, (ledNum * 3) + 4);
  ModbusRTUServer.configureInputRegisters(_startIReg, (ledNum * 3) + 4);
  ModbusRTUServer.configureDiscreteInputs(_startDIReg, ledNum);


  #if defined(__AVR_ATtiny85__) && (F_CPU == 16000000)
    clock_prescale_set(clock_div_1);
  #endif

  pixels.begin(); 
  pixelWriteIndex = _startHReg + (ledNum * 3);
  pixelReadIndex = _startIReg + (ledNum * 3);

  ModbusRTUServer.holdingRegisterWrite(pixelWriteIndex, 252);
  ModbusRTUServer.holdingRegisterWrite(pixelWriteIndex + 1, 186);
  ModbusRTUServer.holdingRegisterWrite(pixelWriteIndex + 2, 3);
  ModbusRTUServer.holdingRegisterWrite(pixelWriteIndex + 3, 5);
}

void loop() {

  ModbusRTUServer.poll();

    // SET MIN OR MAX
  int holdingIndex2 = _startHReg;
  int startInputReg = _startIReg;
  for (int i = 0; i < ledNum; i++)
  {
    int m = ModbusRTUServer.holdingRegisterRead(holdingIndex2);         // read min value 
    int M = ModbusRTUServer.holdingRegisterRead(holdingIndex2 + 1);     // read max value
    dimmers[i].SetMinMax(m, M);
    ModbusRTUServer.inputRegisterWrite(startInputReg, m);       // update user interface
    ModbusRTUServer.inputRegisterWrite(startInputReg + 1, M);       // update user interface
    holdingIndex2 + 3;
    startInputReg + 3;
  }

  // PASSO PASSO DA MODBUS
  int coilIndex = _startCoil;
  int discretIndex = _startDIReg;
  for (int i = 0; i < ledNum; i++)
  {
    int coilOn = ModbusRTUServer.coilRead(coilIndex);                     // read ON value from coil
    int coilOff = ModbusRTUServer.coilRead(coilIndex + 1);                // read OFF value from coil
    bool setIStatus = dimmers[i].SetOnOff(coilOn, coilOff);               // send the value to the Led Function and take if is on or off
    ModbusRTUServer.discreteInputWrite(discretIndex, setIStatus);
    if (coilOn)
    {
      ModbusRTUServer.coilWrite(coilIndex, 0);                            // set false the ON register for the next cicle
    }
    if (coilOff)
    {
      ModbusRTUServer.coilWrite(coilIndex + 1, 0);                        // set false the OFF register for the next cicle
    }
    coilIndex += 2;
    discretIndex += 1;
  }

  // DIM DA MODBUS
  int holdingIndex1 = _startHReg;
  int inputIndex1 = _startIReg + 2;
  int discretIndex1 = _startDIReg;
  for (int i = 0; i < ledNum; i++)
  {
    int mdim = (int)ModbusRTUServer.holdingRegisterRead(holdingIndex1+2);          // read the dim register
    int setDim = dimmers[i].SetDim(mdim);                                           // set the dim
    ModbusRTUServer.holdingRegisterWrite(holdingIndex1+2, 0);                      // set 0 the dim register

    ModbusRTUServer.inputRegisterWrite(inputIndex1, setDim);                   // update the user interface with brightness value
    if (setDim != 0)
    {
      ModbusRTUServer.discreteInputWrite(discretIndex1, true);                   // update the user interface led status
    }
    holdingIndex1 += 3;
    inputIndex1 += 3;
    discretIndex1 += 1;
  }
  holdingIndex1 = 0;
  inputIndex1 = 0;
  discretIndex1 = 0;

  int r = ModbusRTUServer.holdingRegisterRead(pixelWriteIndex);
  int g = ModbusRTUServer.holdingRegisterRead(pixelWriteIndex + 1);
  int b = ModbusRTUServer.holdingRegisterRead(pixelWriteIndex + 2);
  int Br = ModbusRTUServer.holdingRegisterRead(pixelWriteIndex + 3);
  // SET PIXEL CHANGE FROM MODBUS
  for(int i=0; i < numpixel; i++) {

    pixels.setPixelColor(i, pixels.Color(r, g, b));
    pixels.setBrightness(Br);
  }
  pixels.show();
  ModbusRTUServer.inputRegisterWrite(pixelReadIndex, r);
  ModbusRTUServer.inputRegisterWrite(pixelReadIndex + 1, g);
  ModbusRTUServer.inputRegisterWrite(pixelReadIndex + 2, b);
  ModbusRTUServer.inputRegisterWrite(pixelReadIndex + 3, Br);

    // check button change
  for(int i = 0; i < ledNum; i++)
  {
    dimmers[i].Start();
  }
}