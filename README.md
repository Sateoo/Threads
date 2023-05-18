# WPFThreads
### Primo utilizzo delle Lambda espression
Si usa un'espressione lambda per creare una funzione anonima. Usare l'operatore di dichiarazione lambda => per separare l'elenco di parametri dell'espressione lambda dal corpo. Un'espressione lambda può essere di una delle due forme seguenti:
* Espressione lambda con espressione, che contiene un'espressione come corpo:
  (input-parameters) => espression
* Espressione lambda con istruzioni, che contiene un blocco di istruzioni come corpo:
  (input-parameters) => { <sequence-of-statements> }
  ## Perchè blocchiamo obj
  la funzione lock permette ad un solo thread alla volta di utilizzare le funzionalità RMW rendendolo atomico
