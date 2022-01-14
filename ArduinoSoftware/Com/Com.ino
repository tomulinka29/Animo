#include <SoftwareSerial.h>
SoftwareSerial softSerial(10, 11);
String toPcString;
String fromPcString;
int rate = 19200;
void setup()  
{
  softSerial.begin(rate);
  Serial.begin(rate);
  
} 
void loop()  
{ 
  if (Serial.available() > 0) {
    fromPcString = Serial.readString();
    //delay(10000);
  softSerial.print(fromPcString);
  }
  if (softSerial.available())
  {
    toPcString=softSerial.readString();
    Serial.print(toPcString);
  }
  
}
