import processing.video.*;

Movie video1;
Movie video2;
Movie noise;

boolean isPressed = false;

void setup() {
  //size(640, 480);
  //surface.setResizable(true);
  fullScreen(P2D);
  video1 = new Movie(this, "extra.mp4");
  video2 = new Movie(this, "playthrough.mov");
  noise = new Movie(this, "35mm_G3_DIRTY_v1.mp4");
  video1.loop();
  video1.volume(0);
  video2.volume(0);
  video2.loop();
  noise.loop();
}

void draw() {
  
  clear();
  background(255, 255, 255);
  if(isPressed){
    video1.volume(1);
    video2.volume(0);
  }else{
    video1.volume(0);
    video2.volume(1);
  }
  image(isPressed ? video1 : video2, 0, 0, width, height);
  //image(video2, 0, 0);
  //blend(noise, 0, 0, 200, 200, 0, 0, 200, 200, LIGHTEST); 
     
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
    isPressed =!isPressed;
  }
}