# RentalProject
Project for MotorcycleRental

Para o projeto funcionar é preciso rodar as migrations:

    1° Add-Migration InitialDB -Context MotorcycleRentalDBContext

    2° Update-Database -Context MotorcycleRentalDBContext

O proximo passo seria adicionar no banco de dados os planos(pode ser adicionado pelo swaggger):

    - periodValue=30, periodType=7,ticketValue=0.2

    - periodValue=28, periodType=15,ticketValue=0.4
    
    - periodValue=22, periodType=30,ticketValue=0.6

Pronto! Agora voce ja consegue utilizar o sistema

Obs: O resto das informações que eram fixas como por exemplo os perfis realizei a logica como eles sendo Enuns, logo não existe tabela para guardar essas informações.
