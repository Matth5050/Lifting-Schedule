using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Routine.Models;
using System;

namespace Routine.Tests
{
  [TestClass]
  public class ExercisesTests : IDisposable
  {

    public void Dispose()
    {
      Exercise.ClearAll();
    }

    [TestMethod]
    public void ExerciseConstructor_CreatesInstanceOfExercise_Exercise()
    {
      Exercise newExercise = new Exercise("test");
      Assert.AreEqual(typeof(Exercise), newExercise.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";

      //Act
      Exercise newExercise = new Exercise(description);
      string result = newExercise.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Exercise newExcercise = new Exercise(description);

    //   //Act
    //   string updatedDescription = "Do the dishes";
    //   newExercise.Description = updatedDescription;
    //   string result = newExercise.Description;

    //   //Assert
    //   Assert.AreEqual(updatedDescription, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ExerciseList()
    {
      // Arrange
      List<Exercise> newList = new List<Exercise> { };

      // Act
      List<Exercise> result = Exercise.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsExercises_ExerciseList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Exercise newExercise1 = new Exercise(description01);
      Exercise newExercise2 = new Exercise(description02);
      List<Exercise> newList = new List<Exercise> { newExercise1, newExercise2 };

      //Act
      List<Exercise> result = Exercise.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ExerciseInstantiateWithAnIdAndGetterReturn_Int()
    {
      string description = "walk the dog.";
      Exercise newExercise = new Exercise(description);
      int result = newExercise.Id;
      Assert.AreEqual(1,result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Song()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Exercise newExercise1 = new Exercise(description01);
      Exercise newExercise2 = new Exercise(description02);

      //Act
      Exercise result = Exercise.Find(2);

      //Assert
      Assert.AreEqual(newExercise2, result);
    }
  }
}