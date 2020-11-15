using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.DrawingVerbs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Software_Engineering {

    /// <summary>
    /// This class is responsible for creating Verbs.
    /// </summary>
    public class VerbFactory {

        /// <summary>
        /// This function returns a IVerb from a command and drawer.
        /// </summary>
        /// <remarks>
        /// This factory is specifically useful since it automatically converts the parameters to what they should be.
        /// </remarks>
        /// <param name="drawer">The drawer to affect</param>
        /// <param name="fullCommand">The command as a string</param>
        /// <returns>A IVerb that maches the command</returns>
        public static IVerb MakeVerb(Drawer drawer, string fullCommand) {
            Dictionary<string, string[]> commandAndParameters = SettingsAndHelperFunctions.CommandAndParameterParser(fullCommand);

            if (!commandAndParameters.Keys.Contains("command")) throw new Exception("There is no command to process");

            string command = commandAndParameters["command"][0];
            string[] parameters = commandAndParameters.Keys.Contains("parameters") ? commandAndParameters["parameters"] : new string[] { };
            int parameterLength = parameters.Length;

            switch (command) {
                //Drawing commands
                case "move":
                case "moveto":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new MoveTo(drawer,
                            ValueHelper.ConvertToInt(parameters[0]),
                            ValueHelper.ConvertToInt(parameters[1]));
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "drawto":
                case "line":
                case "lineto":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new
                            DrawTo(drawer,
                            ValueHelper.ConvertToInt(parameters[0]),
                            ValueHelper.ConvertToInt(parameters[1]));
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "regularpolygon":
                case "rp":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new
                            RegularPolygon(drawer,
                            ValueHelper.ConvertToInt(parameters[0]),
                            ValueHelper.ConvertToDouble(parameters[1])
                            );
                    } else if (parameterLength == 3) {
                        return new RegularPolygon(drawer,
                            ValueHelper.ConvertToInt(parameters[0]),
                            ValueHelper.ConvertToDouble(parameters[1]),
                            ValueHelper.ConvertToDouble(parameters[2])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "square":
                    //Check parameters
                    if (parameterLength == 1) {
                        return new
                            Square(drawer,
                            ValueHelper.ConvertToDouble(parameters[0])
                            );
                    } else if (parameterLength == 2) {
                        return new Square(drawer,
                            ValueHelper.ConvertToDouble(parameters[0]),
                            ValueHelper.ConvertToDouble(parameters[1])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "quadrilateral":
                    //Check parameters
                    if (parameterLength == 8) {
                        return new Quadrilateral(drawer,
                            ValueHelper.ConvertToPoint(parameters[0], parameters[1]),
                            ValueHelper.ConvertToPoint(parameters[2], parameters[3]),
                            ValueHelper.ConvertToPoint(parameters[4], parameters[5]),
                            ValueHelper.ConvertToPoint(parameters[6], parameters[7])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "rectangle":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new Rectangle(drawer,
                            ValueHelper.ConvertToDouble(parameters[0]),
                            ValueHelper.ConvertToDouble(parameters[1])
                            );
                    } else if (parameterLength == 8) {
                        return new Quadrilateral(drawer,
                            ValueHelper.ConvertToPoint(parameters[0], parameters[1]),
                            ValueHelper.ConvertToPoint(parameters[2], parameters[3]),
                            ValueHelper.ConvertToPoint(parameters[4], parameters[5]),
                            ValueHelper.ConvertToPoint(parameters[6], parameters[7])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "circle":
                    //Check parameters
                    if (parameterLength == 1) {
                        return new
                            Circle(drawer,
                            ValueHelper.ConvertToDouble(parameters[0])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "triangle":
                    //Check parameters
                    if (parameterLength == 1) {
                        return new
                            Triangle(drawer,
                            ValueHelper.ConvertToDouble(parameters[0])
                            );
                    } else if (parameterLength == 2) {
                        return new
                            Triangle(drawer,
                            ValueHelper.ConvertToDouble(parameters[0]),
                            ValueHelper.ConvertToDouble(parameters[1])
                            );
                    } else if (parameterLength == 6) {
                        return new Triangle(drawer,
                            ValueHelper.ConvertToPoint(parameters[0], parameters[1]),
                            ValueHelper.ConvertToPoint(parameters[2], parameters[3]),
                            ValueHelper.ConvertToPoint(parameters[4], parameters[5])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "dot":
                    if (parameterLength == 0) {
                        return new Dot(drawer);
                    } else throw new Exception(command + " doesn't take parameters");

                case "clear":
                    if (parameterLength == 0) {
                        return new Clear(drawer);
                    } else throw new Exception(command + " doesn't take parameters");

                case "reset":
                case "resetpen":
                    if (parameterLength == 0) {
                        return new ResetPen(drawer);
                    } else throw new Exception(command + " doesn't take parameters");

                case "fillon":
                    if (parameterLength == 0) {
                        return new Fill(drawer, true);
                    } else throw new Exception(command + " doesn't take parameters");

                case "filloff":
                    if (parameterLength == 0) {
                        return new Fill(drawer, false);
                    } else throw new Exception(command + " doesn't take parameters");

                case "pen":
                    if (parameterLength == 1) {
                        return new PenColor(drawer, ValueHelper.TextToColor(parameters[0]));
                    } else if (parameterLength == 3) {
                        return new PenColor(drawer,
                            ValueHelper.IntsToColor(
                                ValueHelper.ConvertToInt(parameters[0]),
                                ValueHelper.ConvertToInt(parameters[1]),
                                ValueHelper.ConvertToInt(parameters[2])
                                )
                            );
                    } else if (parameterLength == 4) {
                        return new PenColor(drawer,
                            ValueHelper.IntsToColor(
                                ValueHelper.ConvertToInt(parameters[0]),
                                ValueHelper.ConvertToInt(parameters[1]),
                                ValueHelper.ConvertToInt(parameters[2]),
                                ValueHelper.ConvertToInt(parameters[3])
                                )
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");
                case "fill":
                    if (parameterLength == 1) {
                        return new FillColor(drawer, ValueHelper.TextToColor(parameters[0]));
                    } else if (parameterLength == 3) {
                        return new FillColor(drawer,
                            ValueHelper.IntsToColor(
                                ValueHelper.ConvertToInt(parameters[0]),
                                ValueHelper.ConvertToInt(parameters[1]),
                                ValueHelper.ConvertToInt(parameters[2])
                                )
                            );
                    } else if (parameterLength == 4) {
                        return new FillColor(drawer,
                            ValueHelper.IntsToColor(
                                ValueHelper.ConvertToInt(parameters[0]),
                                ValueHelper.ConvertToInt(parameters[1]),
                                ValueHelper.ConvertToInt(parameters[2]),
                                ValueHelper.ConvertToInt(parameters[3])
                                )
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");

                default:
                    throw new Exception("Unknown command");
            }
        }
    }
}