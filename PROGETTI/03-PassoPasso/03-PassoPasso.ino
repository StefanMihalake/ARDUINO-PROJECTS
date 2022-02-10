/*Pulsante sul pin 4 comanda un led sul pin 8*/
//pin declare
char buttonPin=4;
char ledPin=8;
//variable declare
char buttonState=1;
char buttonState2=1;
char oldButtonState=1;
char ledState=0;
char oldLedState=1;

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
  do {
  buttonState=digitalRead(buttonPin);     //read the state of the pin declared ad buttonPin
  delay(10);
  buttonState2=digitalRead(buttonPin);    //read again the state of the pin declared ad buttonPin after few milliseconds
  } while (buttonState!=buttonState2);    //if the 2 read are the same goes on else repeate the reading
}

void ProcessToExe(){
  if(buttonState==LOW && buttonState!=oldButtonState)    //if the program find an rising edge
    ledState=(ledState+1)%2;        //change the ledState
  oldButtonState=buttonState;     //save the current buttonState as oldbuttonState for the next cycle   
}

void WriteOutput(){
  if(ledState!=oldLedState){     //if the state of the led need to change
    //Serial.println("1");
    digitalWrite(ledPin, ledState);     //set the pin declared as ledPin as variable ledState
    oldLedState=ledState;       //and save the current ledState as oldLedState for the next cycle
  }
}
