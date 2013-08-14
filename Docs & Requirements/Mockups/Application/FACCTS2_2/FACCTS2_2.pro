#-------------------------------------------------
#
# Project created by QtCreator 2013-05-13T12:33:00
#
#-------------------------------------------------

QT       += core gui sql xml

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = FACCTS2_2
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    export.cpp \
    confirm.cpp \
    newcase.cpp \
    consolidate.cpp \
    adddocket.cpp \
    userupdate.cpp \
    ordersave.cpp \
    seperate.cpp \
    reissue.cpp \
    qxmlputget.cpp \
    continuance.cpp \
    casestatus.cpp \
    addrelatedcase.cpp \
    generateorders.cpp \
    renewcase.cpp \
    addparties.cpp \
    removedocket.cpp \
    casesave.cpp

HEADERS  += mainwindow.h \
    export.h \
    confirm.h \
    newcase.h \
    consolidate.h \
    adddocket.h \
    userupdate.h \
    ordersave.h \
    seperate.h \
    reissue.h \
    qxmlputget.h \
    continuance.h \
    casestatus.h \
    addrelatedcase.h \
    generateorders.h \
    renewcase.h \
    addparties.h \
    removedocket.h \
    casesave.h

FORMS    += mainwindow.ui \
    export.ui \
    confirm.ui \
    newcase.ui \
    consolidate.ui \
    adddocket.ui \
    userupdate.ui \
    ordersave.ui \
    seperate.ui \
    reissue.ui \
    continuance.ui \
    casestatus.ui \
    addrelatedcase.ui \
    generateorders.ui \
    renewcase.ui \
    addparties.ui \
    removedocket.ui \
    casesave.ui

RESOURCES += \
    Images.qrc
