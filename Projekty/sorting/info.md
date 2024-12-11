    public static int czestosc(String slowo, char c){
        int c1 = 0;
        
        for(int i = 0; i < slowo.Length; i++){
            if(slowo[i] == c){
                c1++;
            }
        
        }
        return c1;
    }
    
    public static void Main(string[] args){
        String word = "test";
        Console.WriteLine(czestosc(word,'t'));
        
        var lista = new List<NodeT>();
        lista = lista.OrderBy(n => n.czestosc).ToList();
    }
