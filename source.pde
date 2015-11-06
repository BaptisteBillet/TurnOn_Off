import processing.video.*;

Movie sexyVideo;
Movie unsexyVideo;
Movie noise;
float speedDecrease = 0.5;
float startTime = 0;
float countPress = 0;
float numPresses = 10;
float lastMillis = 0;
float startChangeTime = 0;
boolean onSexy = true;

float sexyTime = 0;
float unSexyTime = 0;


void setup() {
  size(640, 480);
  //surface.setResizable(true);
  //fullScreen(P2D);
  sexyVideo = new Movie(this, "playthrough.mov");
  unsexyVideo = new Movie(this, "extra.mp4");
  noise = new Movie(this, "TVnoise.mp4");
  sexyVideo.loop();
  unsexyVideo.loop();
  noise.loop();
  startChangeTime = 1000000;
  resetVideo();
}

void draw() {
  float deltaTime = (millis() - lastMillis) / frameRate;
  clear();
  if(millis() - startTime > 10000){
    if(onSexy){
      sexyTime = ((millis() - startTime)-10000)/1000;
    }else{
      unSexyTime = ((millis() - startTime)-10000)/1000;
    }
    
  }
  
  if(millis() - startTime < 400){
    noise.volume(1);
    unsexyVideo.volume(0);
    sexyVideo.volume(0);
    image(noise, 0, 0, width, height);
  }
  else if(onSexy){
    println("onSexy");
    noise.volume(0);
    sexyVideo.volume(1);
    unsexyVideo.volume(0);
    image(sexyVideo, 0, 0, width, height);
  }else{
    noise.volume(0);
    sexyVideo.volume(0);
    unsexyVideo.volume(1);
    image(unsexyVideo, 0, 0, width, height);
  }
  noStroke();
  fill(255,0,0);  
  //rect(0,height-20, width * 0.5, height);
  rect(0,height-10,countPress/numPresses * width, height);

  textSize(22);
  textAlign(LEFT);
  text("Sexy: " + nf(sexyTime, 1, 1), 20, 30);
  textAlign(RIGHT);
  text("Patonic: " + nf(unSexyTime, 1, 1), width - 20, 30); 
 
  if(countPress>0)
  countPress -= deltaTime * speedDecrease;
  lastMillis = millis();
  if(millis() - startChangeTime > 5000){
    resetVideo();
  }

}

// Called every time a new frame is available to read
void movieEvent(Movie m) {
  m.read();
}
void keyReleased() {
  if (key == ' ') {
    //isPressed =false;
  }
}
void keyPressed() {
  if (key == ' ') {
    countPress++;
  }
  if(countPress >= numPresses){
    changeVideo();
    changeStarted();
  }
}
void changeStarted(){
  println("changeStarted");
    startChangeTime = millis();
}
void changeVideo(){
    println("changeVideo");
    startTime = millis();
    countPress = 0;
    onSexy =!onSexy;
  
}

void resetVideo(){
    println("reset");
    startTime = millis()-400;
    
    sexyVideo.jump(0);
    unsexyVideo.jump(0);
    
    noise.volume(0);
    unsexyVideo.volume(0);
    sexyVideo.volume(0);
    startChangeTime = 1000000;
}