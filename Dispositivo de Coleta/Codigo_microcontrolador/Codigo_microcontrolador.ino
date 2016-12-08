//Projeto inicial, será usado um arduino uno
//Ethernet esp8266, rtc, multplexadores de 16 canais,
//celulas de peso 50kg half bridge,
//sensores e receptores infravermelho



void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("iniciando");
  contarAbelhas(100000,A0);
  Serial.println("tempoAcabou");
}
int cont =0;
void loop() {
}
int contarAbelhas(long tempo,const int porta){
  unsigned long previousMillis = 0;  
  const long interval = tempo;   
  unsigned long currentMillis = millis();      
  int cont = 0;
  previousMillis = currentMillis;
  while(currentMillis - previousMillis <= interval){
    currentMillis = millis();
    if(analogRead(porta)>1000){
      Serial.println(cont++);
      while(analogRead(A0)>1000){
        //Serial.println("abelhas parada");
        delay(1);
      }
    }
  
    
  }
  return cont;
}

