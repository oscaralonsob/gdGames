using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public class PseudoRandomGenerator
{
  List<int> PossibleValues { set; get; }
  private int CurrentIndex { set; get; }
  private Random Random { set; get; }

  public PseudoRandomGenerator(int possibleValues) {
    Random = new Random();
    CurrentIndex = 0;
    PossibleValues = new List<int>();

    for (int i = 0; i < possibleValues; i++) {
      PossibleValues.Add(i);
    }
    shuffle();
  }

  private void shuffle() {
    var currentValues = PossibleValues.OrderBy(item => Random.Next());

    PossibleValues = new List<int>();
    foreach (int value in currentValues) {
      PossibleValues.Add(value);
    }
  }

  public int Next() {
    CurrentIndex++;
    
    if (CurrentIndex == PossibleValues.Count) {
      CurrentIndex = 0;
      shuffle();
    }

    return PossibleValues[CurrentIndex];
  }

  public float Next(float min, float max) {
    if (min == max) {
      return min;
    }

    int value = Next();

    float difference = Math.Abs(max - min);

    return min + difference * value / PossibleValues.Count;
  }
}
