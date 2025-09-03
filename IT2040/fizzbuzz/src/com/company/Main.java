package com.company;

public class Main {

    public static void main(String[] args)
    {
        for(int i = 1; i <= 100; i++ )
        {
            String str = "";

            if(i % 3 == 0) {str += "fizz";}
            if(i % 5 == 0) {str += "buzz";}
            if(str.equals("")) { str = String.valueOf(i);}

            System.out.println(str);
        }
    }
}
