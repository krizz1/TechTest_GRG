public void TipTop()
{
    for (int i = 25; i <= 250; i++)
    {
   	 if (i % 3 == 0 && i % 5 == 0)
   	 {
   		 Console.WriteLine("TipTop");
   		 continue;
   	 }
   	 else if (i % 5 == 0)
   	 {
   		 Console.WriteLine("Top");
   		 continue;
   	 }
   	 else if (i % 7 == 0)
   	 {
   		 Console.WriteLine("Tip");
   		 continue;
   	 }
   	 else
   	 {
   		 Console.WriteLine(i);
   	 }
    }
}