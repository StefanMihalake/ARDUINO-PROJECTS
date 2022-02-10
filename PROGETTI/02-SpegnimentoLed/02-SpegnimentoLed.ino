/*Pulsante sul pin 4 comanda un led sul pin 8*/
//pin declare
char buttonPin=4;
char ledPin=8;
//variable declare
char buttonState=1;
char ledState=0;
char oldLedState=1;

void setup() {
  // put your setup code here, to run once:
  pinMode(ledPin, OUTPUT);        //set the ledPin in output mode
  pinMode(buttonPin, INPUT_PULLUP);     //set the buttonPin in input mode with pullup
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
  if(buttonState==LOW)    //if the button is pressed
    ledState=LOW;        //set the ledState as LOW
  else                    //if the button isn't pressed
    ledState=HIGH;         //set the ledState as HIGH
}

void WriteOutput(){
  if(ledState!=oldLedState){     //if the state of the led need to change
    digitalWrite(ledPin, ledState);     //set the pin declared as ledPin as variable ledState
    oldLedState=ledState;       //and save the current ledState as oldLedState for the next cycle 
  }
}
