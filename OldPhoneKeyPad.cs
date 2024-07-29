using System;
using System.Text;

public class OldPhoneKeyPad
{
    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePad("33#"));
        Console.WriteLine(OldPhonePad("227*#"));
        Console.WriteLine(OldPhonePad("4433555 555666#"));
        Console.WriteLine(OldPhonePad("8 88777444666*664#"));
    }
   
    public static string OldPhonePad(string input) {
    
        string[] map = new string[] {" ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};// map stores the value statically
        
        StringBuilder result = new StringBuilder();
        int lastChar = -1; // -1 for reset
        int count = 0; // number of times last char was pressed

        foreach (char ch in input) {
            switch (ch) {
                case '#': //end case
                    if (count != 0) {
                        int index = lastChar; // getting last pressed index for map
                        result.Append(map[index][(count - 1) % map[index].Length]);
                    }
                    lastChar = -1;
                    count = 0;
                    break;

                case '*': // reset the last char and count
                    lastChar = -1;
                    count = 0;
                    break;

                case ' ': // if space, add alphabet to result and reset lastChar and count
                    if (count != 0) {
                        int index = lastChar;
                        result.Append(map[index][(count - 1) % map[index].Length]); //modulus to handle cycle through keys
                    }
                    lastChar = -1;
                    count = 0;
                    break;

                default: // any digit between 0 and 9
                    int curChar = ch - '0'; // get integeral value for comparison and addition
                    if (lastChar == curChar) { // if same key was pressed, increment count
                        count++;
                    } else { // different key was pressed, compute previous character and reset values for new number pressed
                        if (count != 0) {
                            int index = lastChar;
                            result.Append(map[index][(count - 1) % map[index].Length]);
                        }
                        lastChar = curChar; //set to the current number being pressed
                        count = 1; // count will be 1 as it is already pressed
                    }
                    break;
            }
            if (ch == '#') {
                break;
            }
        }

        return result.ToString();
    }
}
