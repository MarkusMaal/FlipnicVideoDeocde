# FlipnicVideoDeocde
This tool can help you to extract frames from low-res FMV-s from Flipnic (PS2 game) that have been recorded using video capture software.

![image](https://user-images.githubusercontent.com/45605071/156902955-325008bb-6b89-4f7d-8c65-bb537bc7f77e.png)

## Preparations - what you need to do before using this software
1. First you need to capture a broken FMV clip from Flipnic. To do this, you must replace a hi-resolution FMV that is supposed to play with a low-res one that you want to extract frames from. The hi-resolution FMV-s include the following:
  * UBI.PSS (Ubisoft logo)
  * SHUKYAKUDEMO.PSS (The intro, works, but you may not get the audio data if you replace this one)
  * TITLE_.PSS (the title screen)
  * SILVER_DROP.PSS (Biology A opening)
  * CIRCLE_OF_LIFE.PSS (circle of life mission cutscene in Biology A)
  * FREEZE_OVER.PSS (freeze over mission cutscene in Biology A)
  * TAKIWARI.PSS (hidden path discovery mission cutscene in Biology A)
  * SILVER_DROP2.PSS (Biology B opening)
  * CIRCLE_OF_LIFE2.PSS (circle of life mission cutscene in Biology B)
  * FREEZE_OVER2.PSS (freeze over mission cutscene in Biology B)
  * TAKIWARI2.PSS (hidden path discovery mission cutscene in Biology B)
  * WATCH_OUT.PSS (big UFO warning cutscene in Biology stages)
  * MISSING.PSS (big UFO invasion cutscene in Biology stages, the one where the ball is stolen)
2. These cutscenes can be swapped using the memory view feature in some debugging tools, such as Cheat Engine. Just search for them in memory.
3. As an example, to replace UBI.PSS with GAME_OVER2.PSS (which is one of the game over cutscenes), you first change UBI.PSS in memory to GAME_OVER2.PSS and ALSO change where the GAME_OVER2.PSS reference actually is supposed to be with UBI.PSS. Make sure to add null bytes (00) if the replaced name is shorter.
4. If you did everything right, the next time you trigger the chosen cutscene (UBI.PSS in this example), the replaced cutscene will play, but it'll look broken (which is what we want)
5. Hit record on your screen recording software BEFORE triggering the cutscene. After recording has started, wait until the cutscene finishes playing, then stop recording.
6. Convert the recording into a sequence of images. This can be done using ffmpeg for example.

## How to use
1. After compiling, open the "Flipnic Video Decode" executable
2. Click "Open" and select all of the images you converted the recording to
3. Use the track bar to scroll through the images. You should now see three different images - the top left one is RGB data, right from that is Alpha data (basically the transparancy key), and in front of the checkerboard pattern, you should see the final converted frame.
4. Play around with changing the values on different textboxes.
5. You can also hit "Play" to preview the video, tough the playback maybe a little bit slow, depending on your PC
6. Click "Export sequence" to convert the imported series of images to another series of images, but this time, instead of the broken mess, you should have every frame of the cutscene with translucency data
7. Use ffmpeg again to convert the series of images back into a video file. To get a video file with translucency data, use the following syntax:
  * `ffmpeg -i in%%d.png -vcodec png [desired filename].mov` - this will give you an MOV file, which you can use in video editing software
8. Cut out the parts that aren't part of the cutscene in your desired video editing software. Kdenlive (a free program) should be able to export transparent videos, but more professional software should also work.

## Command line
You can specify the file prefix where you want to extract the frames from. So as an example, if the extract files are out1.png, out2.png, out3.png ..., you can use
the following synax: `".\Flipnic Frame Extract.exe" out.png` or `".\Flipnic Frame Extract.exe" out` (both should work)
