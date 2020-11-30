using Advanced_Software_Engineering.Verbs.DrawingVerbs;
using Advanced_Software_Engineering.Verbs.DrawingVerbs.Actions;
using Advanced_Software_Engineering.Verbs.Flow;
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
            ValueStorage rootValueStorage = drawer.GetValueStorage();

            List<VerbChunk> verbChunks = drawer.verbChunks;
            if (verbChunks.Count == 0) verbChunks.Add(null);

            int chunkDepth = verbChunks.Count - 1;
            VerbChunk currentChunk = verbChunks[chunkDepth];

            CommandAndParameterParserResult result = HelperFunctions.CommandAndParameterParser(fullCommand);

            string command = result.getCommand();
            string[] commandParameters = result.getParameters();
            if (command == null) throw new Exception("There is no command to process");

            IVerb tmpVerb = null;
            bool parsed = false;

            //check for names in directory
            if (rootValueStorage.CheckVariableExists(command)) {
                if (commandParameters.Length == 1) {
                    tmpVerb = new UpdateVariable(rootValueStorage, command, commandParameters[0]);
                    if (chunkDepth == 0) return tmpVerb;
                    currentChunk.AddVerb(tmpVerb);
                    return new NoOp();
                } else throw new Exception(command + "needs something to be assigned to it");
            }

            //process declarations
            if (!(commandParameters == null) && !parsed) {
                switch (command) {
                    case "var":
                        if (commandParameters.Length == 1) {
                            tmpVerb = new DeclareVariable(rootValueStorage, commandParameters[0]);
                            if (chunkDepth == 0) return tmpVerb;
                            currentChunk.AddVerb(tmpVerb);
                            return new NoOp();
                        } else throw new Exception(command + "s need to be initialised");

                    default:
                        //assignment
                        if (rootValueStorage.CheckVariableExists(command)) {
                            string[] assignmentCommands = command.Split("="[0]);
                            if (assignmentCommands.Length > 2) throw new Exception("Cannot have two assignments");
                            tmpVerb = new UpdateVariable(rootValueStorage, assignmentCommands[0], ValueFactory.CreateValue(rootValueStorage, assignmentCommands[1]));
                            if (chunkDepth == 0) return tmpVerb;
                            currentChunk.AddVerb(tmpVerb);
                            return new NoOp();
                        }
                        break;
                    }
                }


            //Parse flow verbs
            switch (command) {
                case "if":
                    if (commandParameters.Length == 1) {
                        verbChunks.Add(new IfChunk(ValueFactory.CreateValue(rootValueStorage, commandParameters[0])));
                        chunkDepth = verbChunks.Count - 1;
                        currentChunk = verbChunks[chunkDepth];
                        parsed = true;
                        tmpVerb = new NoOp();
                    } else if (commandParameters.Length >= 2) {
                        string commandAfterIf = fullCommand.Substring(fullCommand.IndexOf(",") + 1); // find the first ,
                        IValue conditional = ValueFactory.CreateValue(rootValueStorage, commandParameters[0]); //make the conditional
                        IVerb AfterIf = MakeVerb(drawer, commandAfterIf); //make the following command 
                        tmpVerb = new IfChunk(conditional, AfterIf); //Create the chunk
                        parsed = true;
                    } else throw new Exception(command + " has an incorrect number of parameters");
                    break;
            }

            if (!parsed) {
                List<IValue> parameters = new List<IValue>();
                if (!(commandParameters == null)) foreach (string parameter in commandParameters) {
                        parameters.Add(ValueFactory.CreateValue(rootValueStorage, parameter));
                    }
                int parameterLength = parameters.Count;

                //process drawing commands and extras
                switch (command) {
                    //Drawing commands
                    case "move":
                    case "moveto":
                        //Check parameters
                        if (parameterLength == 2) {
                            tmpVerb = new MoveTo(drawer, new PointValue(parameters[0], parameters[1]));
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "drawto":
                    case "line":
                    case "lineto":
                        //Check parameters
                        if (parameterLength == 2) {
                            tmpVerb = new DrawTo(drawer, new PointValue(parameters[0], parameters[1]));
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "regularpolygon":
                    case "rp":
                        //Check parameters
                        if (parameterLength == 2) {
                            tmpVerb = new RegularPolygon(drawer, parameters[0], parameters[1], new IntValue(0), new BoolValue(true));
                        } else if (parameterLength == 3) {
                            tmpVerb = new RegularPolygon(drawer, parameters[0], parameters[1], parameters[2], new BoolValue(true));
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "square":
                        //Check parameters
                        if (parameterLength == 1) {
                            tmpVerb = new
                                Square(drawer, parameters[0]);
                        } else if (parameterLength == 2) {
                            tmpVerb = new Square(drawer, parameters[0], parameters[1]);
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "quadrilateral":
                        //Check parameters
                        if (parameterLength == 8) {
                            tmpVerb = new Quadrilateral(drawer,
                                new PointValue(parameters[0], parameters[1]),
                                new PointValue(parameters[2], parameters[3]),
                                new PointValue(parameters[4], parameters[5]),
                                new PointValue(parameters[6], parameters[7])
                                );
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "rectangle":
                        //Check parameters
                        if (parameterLength == 2) {
                            tmpVerb = new Rectangle(drawer, parameters[0], parameters[1]);
                        } else if (parameterLength == 8) {
                            tmpVerb =  new Quadrilateral(drawer,
                                new PointValue(parameters[0], parameters[1]),
                                new PointValue(parameters[2], parameters[3]),
                                new PointValue(parameters[4], parameters[5]),
                                new PointValue(parameters[6], parameters[7])
                                );
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "circle":
                        //Check parameters
                        if (parameterLength == 1) {
                            tmpVerb = new Circle(drawer, parameters[0]);
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "triangle":
                        //Check parameters
                        if (parameterLength == 1) {
                            tmpVerb = new
                                Triangle(drawer, parameters[0]);
                        } else if (parameterLength == 2) {
                            tmpVerb = new
                                Triangle(drawer, parameters[0], parameters[1]);
                        } else if (parameterLength == 6) {
                            tmpVerb = new Triangle(drawer,
                                new PointValue(parameters[0], parameters[1]),
                                new PointValue(parameters[2], parameters[3]),
                                new PointValue(parameters[4], parameters[5])
                                );
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "dot":
                        if (parameterLength == 0) {
                            tmpVerb = new Dot(drawer);
                        } else throw new Exception(command + " doesn't take parameters");
                        break;

                    case "clear":
                        if (parameterLength == 0) {
                            tmpVerb = new Clear(drawer);
                        } else throw new Exception(command + " doesn't take parameters");
                        break;

                    case "reset":
                    case "resetpen":
                        if (parameterLength == 0) {
                            tmpVerb = new ResetPen(drawer);
                        } else throw new Exception(command + " doesn't take parameters");
                        break;

                    case "fillon":
                        if (parameterLength == 0) {
                            tmpVerb = new Fill(drawer, true);
                        } else throw new Exception(command + " doesn't take parameters");
                        break;

                    case "filloff":
                        if (parameterLength == 0) {
                            tmpVerb = new Fill(drawer, false);
                        } else throw new Exception(command + " doesn't take parameters");
                        break;

                    case "pen":
                        if (parameterLength == 1) {
                            tmpVerb = new PenColor(drawer, parameters[0]);
                        } else if (parameterLength == 3) {
                            tmpVerb = new PenColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2]));
                        } else if (parameterLength == 4) {
                            tmpVerb = new PenColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2], parameters[3]));
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    case "fill":
                        if (parameterLength == 1) {
                            tmpVerb = new FillColor(drawer, parameters[0]);
                        } else if (parameterLength == 3) {
                            tmpVerb = new FillColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2], new IntValue(255)));
                        } else if (parameterLength == 4) {
                            tmpVerb = new FillColor(drawer, new ColorValue(parameters[0], parameters[1], parameters[2], parameters[3]));
                        } else throw new Exception(command + " has an incorrect number of parameters");
                        break;

                    //exit flow
                    case "end":
                        if (parameterLength == 0) {
                            if (currentChunk == null) throw new Exception("Cannot end at root level"); //Todo, describe better
                            verbChunks.Remove(currentChunk);
                            chunkDepth = verbChunks.Count - 1;
                            tmpVerb = currentChunk;
                            currentChunk = verbChunks[chunkDepth];
                            
                        } else throw new Exception(command + " doesn't take parameters");
                        break;

                    default:
                        throw new Exception("Unknown command or cannot parse");
                }
            }

            if (chunkDepth == 0) return tmpVerb;
            currentChunk.AddVerb(tmpVerb);
            return new NoOp();
        }
    }
}