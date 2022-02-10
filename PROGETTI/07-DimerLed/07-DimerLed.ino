/*Pulsante sul pin 4 comanda un led sul pin 8. Pulsante su pin 5 comanda un led su pin 9*/
//pin declare
char button1Pin=4;
char button2Pin=5;
char led1Pin=8;
char led2Pin=3;

//variable declare
char button1State1=0;
char button1State2=0;
char oldButton1State=1;

char button2State1=0;
char button2State2=0;
char oldButton2State=1;

char led1State=0;
char oldLed1State=1;
bool enableLed1=false;

char led2State=0;
char oldLed2State=1;
bool enableLed2=false;
bool enableLedDim=false;

unsigned int tStart1=0;
unsigned int tFlowed1=0;

unsigned int tStart2=0;
unsigned int tFlowed2=0;

unsigned int tStart3=0;
unsigned int tFlowed3=0;

char tToFlow=10;
int tToDim=250;
bool dim = false;

unsigned long previousTime = 0;
unsigned long previousTime2 = 0;

class InputSignalFilter{
 
  private:
      int _pin;
      bool _lastStatePin = false;
      unsigned long debounceTemp = 5;
      bool _lastState = false;
      unsigned long tIn;
  
  public:
      InputSignalFilter(int pin, bool lastStatePin, unsigned long debounceTemp, bool lastState);
      
      bool state = false;
      bool trigUp;
      bool trigDown;
      
      void Setup(int pin){
          pinMode(_pin, INPUT);
          _pin = pin;
      }

      void Loop(){
          state = digitalRead(_pin);
          if(state =! _lastState){
            tIn = millis();
            if(state < _lastState){
              trigUp = false;
              trigDown = true;
            }
            else if(state > _lastState){
              trigUp = true;
              trigDown = false;
            }
          }
            _lastState = state;
            if(millis() - tIn > debounceTemp){
              return state;
            }
          
       }
};
      



void setup() {
  
  pinMode(led1Pin, OUTPUT);               //set the led1Pin in output mode
  pinMode(button1Pin, INPUT);             //set the button1Pin in input mode
  pinMode(led2Pin, OUTPUT);               //set the led2Pin in output mode
  pinMode(button2Pin, INPUT);             //set the button2Pin in input mode 
  Serial.begin(9600);

}

void loop() {
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
  unsigned long currentTime = millis();

  InputSignalFilter(led2Pin, ) button2;

  
//  button1State1=digitalRead(button1Pin);        //read the state of the pin declared ad button1Pin
//  button2State1=digitalRead(button2Pin);        //read the state of the pin declared ad button2Pin
//  
//  if(button1State1==HIGH && button1State1!=oldButton1State)    //if the program find an rising edge
//    tStart1=millis();
//  if(button2State1==HIGH && button2State1!=oldButton2State)    //if the program find an rising edge
//    tStart2=millis();
//
//    
//  tFlowed1= millis()-tStart1;
//  tFlowed2= millis()-tStart2;
//  
//  
//  if(tFlowed1>=tToFlow){
//    button1State2=digitalRead(button1Pin);
//    if(button1State1==button1State2)
//      enableLed1=true;
//    else
//      enableLed1=false;
//  }
//
//   if(tFlowed2>=tToFlow){
//     button2State2=digitalRead(button2Pin);
//     if(button2State1==button2State2)
//        enableLed2=true;
//     else
//        enableLed2=false; 
//    }

}





void ProcessToExe(){

  if(button1State1==HIGH && button1State1!=oldButton1State)    //if the program find an rising edge
  {
    led1State=(led1State+1)%2;        //change the ledState
  }
  oldButton1State=button1State1;     //save the current buttonState as oldbuttonState for the next cycle  

  if(button2State1==HIGH && button2State1!=oldButton2State)    //if the program find an rising edge
  {
    led2State=(led2State+1)%2;        //change the ledState
  }  
  oldButton2State=button2State1;     //save the current buttonState as oldbuttonState for the next cycle 

}


void WriteOutput(){
  
  if(led1State!=oldLed1State){            //if the state of the led need to change
      Serial.println("1");
      digitalWrite(led1Pin, led1State);     //set the pin declared as ledPin as variable ledState
      oldLed1State=led1State;               //and save the current ledState as oldLedState for the next cycle
  }
  if(led2State!=oldLed2State){            //if the state of the led need to change
      Serial.println("2");
      digitalWrite(led2Pin, led2State);     //set the pin declared as ledPin as variable ledState
      oldLed2State=led2State;               //and save the current ledState as oldLedState for the next cycle
  }

  
}
