C:\PEMicro\PROGDSC\CPROGDSC INTERFACE=USBMULTILINK PORT=USB1 BDM_SPEED 3 C:\Users\Ar-Ge\Desktop\Vektor-Programlama\1921403000.CFG 
@ECHO. -----------------------------------------------------------------------------
@IF ERRORLEVEL ==1 GOTO Error

@ECHO.
@ECHO. *****************************************************************************
@ECHO.
@ECHO.                     !!! P R O G R A M L A M A    B A S A R I L I !!!   
@ECHO.                              
@ECHO.
@ECHO.                          P R O G R A M M I N G    O K
@ECHO.
@ECHO. *****************************************************************************
color ae
@GOTO END

@ECHO. -----------------------------------------------------------------------------
:Error
@ECHO. -----------------------------------------------------------------------------
@ECHO                                 !!! H A T A !!!
@ECHO. -----------------------------------------------------------------------------
@ECHO.  Programming aborted...
@ECHO. -----------------------------------------------------------------------------
@ECHO.
color ce
@GOTO END

:END				
@PAUSE

