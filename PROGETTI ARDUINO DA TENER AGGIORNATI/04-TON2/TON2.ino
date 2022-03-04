/*Pulsante sul pin 4 comanda un led sul pin 8. Pulsante su pin 5 comanda un led su pin 9*/
//pin declare
char button1Pin=4;
char button2Pin=6;
char led1Pin=8;
char led2Pin=11;

//variable declare
char button1State1=1;
char button1State2=1;
char oldButton1State=1;

char button2State1=1;
char button2State2=1;
char oldButton2State=1;

char led1State=0;
char oldLed1State=1;
bool enableLed1=false;

char led2State=0;
char oldLed2State=1;
bool enableLed2=false;

unsigned int tStart1=0;
unsigned int tFlowed1=0;

unsigned int tStart2=0;
unsigned int tFlowed2=0;

char tToFlow=10;

char tParam=3000;

void setup() {
  
  pinMode(led1Pin, OUTPUT);                     //set the led1Pin in output mode
  pinMode(button1Pin, INPUT_PULLUP);            //set the button1Pin in input mode with pullup
  pinMode(led2Pin, OUTPUT);                     //set the led2Pin in output mode
  pinMode(button2Pin, INPUT_PULLUP);            //set the button2Pin in input mode with pullup
  Serial.begin(9600);
  button1State1=digitalRead(button1Pin);        //read the state of the pin declared ad button1Pin
  button2State1=digitalRead(button2Pin);        //read the state of the pin declared ad button2Pin
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
  
  if(button1State1==LOW && button1State1!=oldButton1State)    //if the program find an rising edge
    tStart1=millis();
  if(button2State1==LOW && button2State1!=oldButton2State)    //if the program find an rising edge
    tStart2=millis();
    
  tFlowed1= millis()-tStart1;
  tFlowed2= millis()-tStart2;
  
  if(tFlowed1>=tToFlow){
    button1State2=digitalRead(button1Pin);
    if(button1State1==button1State2)
      enableLed1=true;
    else
      enableLed1=false;
  }
  if(tFlowed2>=tToFlow){
    button2State2=digitalRead(button2Pin);
    if(button2State1==button2State2)
      enableLed2=true;
    else
      enableLed2=false;
  }
}

void ProcessToExe(){

  if(button1State1==LOW && button1State1!=oldButton1State)    //if the program find an falling edge
      tStart1=millis();                                      //save the current time flowed from the start/restart of the board
  oldButton1State=button1State1;                             //save the current buttonState as oldbuttonState for the next cycle
  tFlowed1=millis()-tStart1;                             //save the current time flowed frome the tStat
  
  if((tFlowed1<=tParam && button1State1==HIGH) || button1State1==LOW)      //if the button is pressed or are flowed less ms than tParamOff
    led1State=HIGH;         //set the ledState as HIGH
  else
    led1State=LOW;         //else set the ledState as LOW



  if(button2State1==LOW && button2State1!=oldButton2State)    //if the program find an falling edge
      tStart2=millis();                                      //save the current time flowed from the start/restart of the board
  oldButton2State=button2State1;                             //save the current buttonState as oldbuttonState for the next cycle
  tFlowed2=millis()-tStart2;                             //save the current time flowed frome the tStat
  
  if((tFlowed2<=tParam && button2State1==HIGH) || button2State1==LOW)      //if the button is pressed or are flowed less ms than tParamOff
    led2State=HIGH;         //set the ledState as HIGH
  else
    led2State=LOW;         //else set the ledState as LOW
  
}

void WriteOutput(){
  if(enableLed1 = true){            //if the state of the led need to change
      Serial.println("1");
      digitalWrite(led1Pin, led1State);     //set the pin declared as ledPin as variable ledState
      oldLed1State=led1State;               //and save the current ledState as oldLedState for the next cycle
  }
  if(enableLed2 = true){            //if the state of the led need to change
      Serial.println("2");
      digitalWrite(led2Pin, led2State);     //set the pin declared as ledPin as variable ledState
      oldLed2State=led2State;               //and save the current ledState as oldLedState for the next cycle
  }
}
