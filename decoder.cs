namespace ConsoleApplication1
{

    //У нас в старом проекте все так пишут
    public static class X111
    {
        public static string GetDecodedMessage(string message, int key)
        {
            int outputLenght = message.Length / 4;
            ushort usht = (ushort)key, usht1;
            char[] arrch=new char[outputLenght];
            for (var i=0; i < outputLenght; i++) 
            {
                usht1 = (ushort)(message[4 * i] - 'a' + ((message[4 * i + 1] - 'a') << '\u0004') + ((message[4 * i + 2] - 'a') << '\u0008') + ((message[4 * i + 3] - 'a') << '\u000c'));
                arrch[i] = (char) (usht1- usht);
                usht += 1789;
            }
            return new string(arrch); 
        }
    }
}
