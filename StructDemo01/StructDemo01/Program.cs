// See https://aka.ms/new-console-template for more information

using StructDemo01;

Resolution hdResolution = new(1920, 1080);
var cinemaResolution = hdResolution;
cinemaResolution.Width = 2048;
Console.WriteLine($"HD resolution is {hdResolution.Width} pixels wide and {hdResolution.Height} pixels height.");
Console.WriteLine($"Cinema resolution is {cinemaResolution.Width} pixels wide and {cinemaResolution.Height} pixels height.");

//VideoMode someVideoMode = new();


