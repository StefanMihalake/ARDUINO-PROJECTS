#include <StefanMLibrery.h>

const int bPin1 = 6;
const int bPin2 = 5;
const int led1 = 9;
const int led2 = 10;


//Dimmer (id, bPin, ledPin, minVal, maxVal, dimTemp, dimDelay)
Dimmer butLed1(1, bPin1, led1, 25, 255, 1500, 250);
Dimmer butLed2(2, bPin2, led2, 25, 255, 1500, 250);


// ISTANCE LIST
Dimmer dimmers[] = {butLed1, butLed2};

//itemNumber, startCoil, startHReg, startIReg, startDIReg)
Orchestrator orch(1, 9600, 2, 100, 200, 100, 100);

void setup() {
  Serial.begin(9600);
  
}

void loop() {

  orch.Start(dimmers);
}
