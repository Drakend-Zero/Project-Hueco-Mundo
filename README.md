# Project-Hueco-Mundo

(**El teclado esta en ingles, disculpen la escritura confusa sin tildes**)

Logica en la que se inspira:

 Tomando ejemplo del anime **Bleach** , este juego te sumerge en el combate contra un enemigo que encontraste en tu exploracion de tu hogar si eliges ser del bando divertido o de tu area enemiga
si eliges el bando de los que hacen el bien, es una batalla de resistencia y mucha paciencia,usando tus habilidades cuando las condiciones lo permitan.

Sucesion de los procesos:

 Inicialmente tenemos una pantalla de carga con una expliacion respecto al objetivo del juego, 
despues de su finalizacion tenemos la pantalla de seleccion del primer jugador en la ingresaremos el numro de la clase de jugador que usaremos(la cual falla si ingresamos un String o Char)
y luego tenemos la pantalla de selccion del segundo jugador,despues y final tenemos la pantalla del juego en la que ,una vez empecemos, podremos mover al primer jugador con WASD
y al segundo con las flechas del teclado y ademas activar una vez cumplidos los requisitos las habilidades de cada clase de jugador.

Logica de cada proceso de comandos con los teclados:

 Existen aclaraciones en las pantallas hasta el inicio del juego que hacen aclaraciones pero a modo de resumen:

--Cualquien tecla en la primera pantalla(preferiblemente esperar que cada parte termine su respectia carga)
--Los numeros correspondientes en las pantallas de seleccion de jugador(preferiblemente esperar que cada parte termine su respectia carga)
+-En caso de elegir Shinigami la habilidad se activa con R.  
+-En caso de elegir Arrancar la habilidad se activa con U.  
+-En caso de elegir Vizard la habilidad se activa con I.
+-En caso de elegir Espada la habilidad se activa con O.
+-En caso de elegir Quincy la habilidad se activa con Barraespaciadora.
--Una vez jugando Escape quita el juego e inicia la sucesion nuevamente.
Condicion de victoria:
Muy simple,gana quien en el transcurso de 20 turnos tenga mayor vida.


