   M S B A M L   `   `   `  ����O  KArduinoCommunication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ArduinoCommunicationArduinoCommunication  5   	   %    ArduinoCommunication.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ArduinoCommunication     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $��3* �6   6*   .+�5   
   �� $
��Left=�6    �� Orientation$ 
Horizontal=�60   $��0��6I   .+�5      �� .+�5      �� .��6   Com port index6(   �� 5      .��6   
Baudrate6"   5      �� 5      $ Vertical=�6   .+�5      �� -   5        $��portBox��5   I   $��50��6   $��25��6&   
�������6Z   �� 5      -   5        $��baudBox��5   H   $��50��6   $��25��6%   
�������6Y   5      5      �� 5   
   -   5        $��sendBox��5      $
��Left=�6!   $��69��6<   $��	10,10,0,0q�6H   $��1��6[    �� TextWrapping$
 Wrap=�6h   $��TextBox��6|   $	��Top=�6�   $	��292��6�   
�������6�   �� 5   
   -   5        $��recBlock��5      $
��Left=�6$   $��1��6@   
�������$��
397,10,0,0q�6d   $
��Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��304��6�   $	��395��6�   �� 5   
   -   5        $��
SendButton��5      $
��Send��6#   $
��Left=�62   $��
75,187,0,0q�6M   $��1��6a   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5        $��	runButton��5      $	��Run��6"   $
��Left=�60   $��
174,10,0,0q�6K   $	��Top=�6_   $��74��6w   6�   5%      5&      