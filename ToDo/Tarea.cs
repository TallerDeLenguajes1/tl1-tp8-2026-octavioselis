namespace EspacioTarea{
    public class Tarea{
        public int TareaID { get; set; }
        public string Descripcion { get; set; } = "";

        int duracion;
        public int Duracion{
            get => duracion;
            set {
                if(value>=10 && value <= 100){
                    duracion = value;
                }else{
                    duracion =10;
                }
            }
        }
    }
}