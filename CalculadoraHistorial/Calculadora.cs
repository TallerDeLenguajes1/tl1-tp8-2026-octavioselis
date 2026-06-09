namespace EspacioCalculadora
{

    public enum TipoOperacion{ 
       Suma, 
       Resta, 
       Multiplicacion, 
       Division, 
       Limpiar  // Representa la acción de borrar el resultado actual o el historial 
   } 
    public class Operacion{ 
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual 
        private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior
        
        private TipoOperacion operacion;// El tipo de operación realizada 
        public double Resultado{ 
        /* Lógica para calcular o devolver el resultado */ 
            get
            {
                switch (operacion)
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division:
                        if (nuevoValor != 0)
                            return resultadoAnterior / nuevoValor;
                        else
                            return 0; 
                    case TipoOperacion.Limpiar:
                        return 0;
                    default:
                        return resultadoAnterior;
                }
            }
        } 
        // Propiedad pública para acceder al nuevo valor utilizado en la operación 
            public double NuevoValor{ 

                get {return nuevoValor;}
            
        } 
        public Operacion(double resAnterior, double nValor, TipoOperacion oper)
        {
            this.resultadoAnterior = resAnterior;
            this.nuevoValor = nValor;
            this.operacion = oper;
        }
    }
        public class Calculadora
        {
            double dato;
            List<Operacion> historial;

            public Calculadora()
            {
                this.dato = 0;
                this.historial = new List<Operacion>();
            }

            public double Resultado
            {
                get {return dato;}
            }

            public void Sumar(double termino)
            {
                Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Suma);
                historial.Add(nuevaOperacion);
                dato = nuevaOperacion.Resultado;
            }

            public void Restar(double termino)
            {
                Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Resta);
                historial.Add(nuevaOperacion);
                dato = nuevaOperacion.Resultado;
            }
            public void Multiplicar(double termino)
            {
                Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Multiplicacion);
                historial.Add(nuevaOperacion);
                dato = nuevaOperacion.Resultado;
            }
            public void Dividir(double termino)
            {   
                if(termino != 0)
                {
                    Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Division);
                    historial.Add(nuevaOperacion);
                    dato = nuevaOperacion.Resultado;
                }
                
            }
            public void Limpiar()
            {
                Operacion nuevaOperacion = new Operacion(dato, 0, TipoOperacion.Limpiar);
                historial.Add(nuevaOperacion);
                dato = nuevaOperacion.Resultado;
            }

            public void MostrarHistorial()
            {
                Console.WriteLine("\n--- HISTORIAL DE OPERACIONES ---");
                foreach (Operacion op in historial)
                {
                    
                    Console.WriteLine($"Operación guardada: {op.NuevoValor} (Resultado parcial: {op.Resultado})"); 
                }
                Console.WriteLine("--------------------------------\n");
            }


    }
            
            
}  

