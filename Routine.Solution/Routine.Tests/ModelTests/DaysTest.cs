using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Models;
using System.Collections.Generic;
using System;

namespace Catalogue.Tests
{
  [TestClass]
  public class AlbumTests : IDisposable
  {

    public void Dispose()
    {
      Album.ClearAll();
    }
    
    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album("test album");
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Album";
      Album newAlbum = new Album(name);

      //Act
      string result = newAlbum.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsAlbumId_Int()
    {
      //Arrange
      string name = "Test Album";
      Album newAlbum = new Album(name);

      //Act
      int result = newAlbum.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllAlbumObjects_AlbumList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Album newAlbum1 = new Album(name01);
      Album newAlbum2 = new Album(name02);
      List<Album> newList = new List<Album> { newAlbum1, newAlbum2 };

      //Act
      List<Album> result = Album.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectAlbum_Album()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Album newAlbum1 = new Album(name01);
      Album newAlbum2 = new Album(name02);

      //Act
      Album result = Album.Find(2);

      //Assert
      Assert.AreEqual(newAlbum2, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      //Arrange
      string description = "Walk the dog.";
      Song newSong = new Song(description);
      List<Song> newList = new List<Song> { newSong };
      string name = "Work";
      Album newAlbum = new Album(name);
      newAlbum.AddSong(newSong);

      //Act
      List<Song> result = newAlbum.Songs;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}