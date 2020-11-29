using Advanced_Software_Engineering.Verbs.DrawingVerbs;
using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueObjects;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System;
using System.Collections.Generic;

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
            CommandAndParameterParserResult result = HelperFunctions.CommandAndParameterParser(fullCommand);

            string command = result.getCommand();
            string[] commandParameters = result.getParameters();
            if (command == null) throw new Exception("There is no command to process");

            //check for names in directory
            if (drawer.CheckVariableExists(command)) {

                if (commandParameters.Length == 1) {
                    //return new UpdateVariable(drawer, );
                } else throw new Exception(command + "needs something to be assigned to it");
            }

            //process declarations
            if (!(commandParameters == null))
                switch (command) {
                    case "int":
                    case "double":
                    case "bool":
                    case "color":
                        if (commandParameters.Length == 1) {
                            return new DeclareVariable(drawer, command, commandParameters[0]);
                        } else throw new Exception(command + "s need to be initialised");

                    default:
                        //assignment
                        if (drawer.CheckVariableExists(command)) {
                            string[] assignmentCommands = command.Split("="[0]);
                            if (assignmentCommands.Length > 2) throw new Exception("Cannot have two assignments");
                            return new UpdateVariable(drawer, assignmentCommands[0], ValueFactory.CreateValue(drawer, assignmentCommands[1]));
                        }
                        break;
                }

            List<IValue> parameters = new List<IValue>();
            if (!(commandParameters == null)) foreach (string parameter in commandParameters) {
                    parameters.Add(ValueFactory.CreateValue(drawer, parameter));
                }
            int parameterLength = parameters.Count;

            //process drawing commands and extras
            switch (command) {
                //Drawing commands
                case "move":
                case "moveto":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new MoveTo(drawer, new PointValue(parameters[0], parameters[1]));
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "drawto":
                case "line":
                case "lineto":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new DrawTo(drawer, new PointValue(parameters[0], parameters[1]));
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "regularpolygon":
                case "rp":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new RegularPolygon(drawer, parameters[0], parameters[1], new IntValue(0), new BoolValue(true));
                    } else if (parameterLength == 3) {
                        return new RegularPolygon(drawer, parameters[0], parameters[1], parameters[2], new BoolValue(true));
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "square":
                    //Check parameters
                    if (parameterLength == 1) {
                        return new
                            Square(drawer, parameters[0]);
                    } else if (parameterLength == 2) {
                        return new Square(drawer, parameters[0], parameters[1]);
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "quadrilateral":
                    //Check parameters
                    if (parameterLength == 8) {
                        return new Quadrilateral(drawer,
                            new PointValue(parameters[0], parameters[1]),
                            new PointValue(parameters[2], parameters[3]),
                            new PointValue(parameters[4], parameters[5]),
                            new PointValue(parameters[6], parameters[7])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "rectangle":
                    //Check parameters
                    if (parameterLength == 2) {
                        return new Rectangle(drawer, parameters[0], parameters[2]);
                    } else if (parameterLength == 8) {
                        return new Quadrilateral(drawer,
                            new PointValue(parameters[0], parameters[1]),
                            new PointValue(parameters[2], parameters[3]),
                            new PointValue(parameters[4], parameters[5]),
                            new PointValue(parameters[6], parameters[7])
                            );
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "circle":
                    //Check parameters
                    if (parameterLength == 1) {
                        return new Circle(drawer, parameters[0]);
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "triangle":
                    //Check parameters
                    if (parameterLength == 1) {
                        return new
                            Triangle(drawer, parameters[0]);
                    } else if (parameterLength == 2) {
                        return new
                            Triangle(drawer, parameters[0], parameters[1]);
                    } else if (parameterLength == 6) {
                        return new Triangle(drawer,
                            new PointValue(parameters[0], parameters[1]),
                            new PointValue(parameters[2], parameters[3]),
                            new PointValue(parameters[4], parameters[5])
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
                        return new PenColor(drawer, parameters[0]);
                    } else if (parameterLength == 3) {
                        return new PenColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2]));
                    } else if (parameterLength == 4) {
                        return new PenColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2], parameters[3]));
                    } else throw new Exception(command + " has an incorrect number of parameters");

                case "fill":
                    if (parameterLength == 1) {
                        return new FillColor(drawer, parameters[0]);
                    } else if (parameterLength == 3) {
                        return new FillColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2], new IntValue(255)));
                    } else if (parameterLength == 4) {
                        return new FillColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2], parameters[3]));
                    } else throw new Exception(command + " has an incorrect number of parameters");

                default:

                    throw new Exception("Unknown command or cannot parse");
            }
        }
    }
}