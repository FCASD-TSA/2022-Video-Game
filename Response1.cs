using Godot;
using System;

public class Response1 : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Connect("pressed",this,"onPress1");
    }
    public void onPress1(){
        NPCText npctext = (NPCText)GetParent();
        NPCText.count1++;
        npctext.dialogue("your mom","response1","response2","response3",1);
        
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}