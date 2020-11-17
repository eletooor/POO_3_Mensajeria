# POO_3_Mensajeria

Podes abrir varios clientes desde .\cliente\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\netcoreapp3.1\WindowsFormsApp1.exe

Protocolo--->
----------------------------------
- codigo:                        -
- 00: cerrar sesion              - 
- 01: enviar mensaje             -
- 02: pedir lista de usuarios    -
- 03: pedir lista de mensajes    -
----------------------------------
**********************************
----------------------------------
- Tramas:                        -
- 00 mi_id                       -
- 01 mi_id receptor_id mensaje   -
- 02 mi_id                       -
- 03 mi_id                       -
----------------------------------
**********************************
//EL PROTOCOLO RESPONDE A UN UNICO STRING SIN ESPACIOS ENTRE SUS TERMINOS
//EJEMPLO:
id_emisor=10, id_receptor=11;
>enviar mensaje_
011011hola mundo
