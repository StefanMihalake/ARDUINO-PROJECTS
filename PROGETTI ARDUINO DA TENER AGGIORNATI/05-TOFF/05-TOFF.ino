/*Pulsante sul pin 4 comanda un led sul pin 8*/
//pin declare
char buttonPin=4;
char ledPin=8;
//variable declare
char buttonState=1;
char oldButtonState=1;
char ledState=0;
char oldLedState=1;
unsigned int tParamOff=3000;
unsigned long tStart=0;
int timeFlowed=0;

void setup() {
  // put your setup code here, to run once:
  pinMode(ledPin, OUTPUT);        //set the ledPin in output mode
  pinMode(buttonPin, INPUT_PULLUP);     //set the buttonPin in input mode with pullup
  //Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  /*=======================================
   * LETTURA INGRESSI
   =========================================*/
  ReadInput();
  /*=======================================
   * PROCESSI
   =========================================*/
  ProcessToExe();
  /*=======================================
   * SCRITTURA USCITE
   =========================================*/
  WriteOutput();
}

void ReadInput(){
  buttonState=digitalRead(buttonPin);     //read the state of the pin declared ad buttonPin
}

void ProcessToExe(){
  if(buttonState==HIGH && buttonState!=oldButtonState)    //if the program find an falling edge
    tStart=millis();                                      //save the current time flowed from the start/restart of the board
  oldButtonState=buttonState;                             //save the current buttonState as oldbuttonState for the next cycle
  timeFlowed=millis()-tStart;                             //save the current time flowed frome the tStat
  if((timeFlowed<=tParamOff && buttonState==HIGH) || buttonState==LOW)      //if the button is pressed or are flowed less ms than tParamOff
    ledState=HIGH;         //set the ledState as HIGH
  else
    ledState=LOW;         //else set the ledState as LOW
}

void WriteOutput(){
  if(){     //if the state of the led need to change
    //Serial.println("1");
    digitalWrite(ledPin, ledState);     //set the pin declared as ledPin as variable ledState
    oldLedState=ledState;       //and save the current ledState as oldLedState for the next cycle
  }
}
