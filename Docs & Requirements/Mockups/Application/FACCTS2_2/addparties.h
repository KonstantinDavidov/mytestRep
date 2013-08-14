#ifndef ADDPARTIES_H
#define ADDPARTIES_H

#include <QDialog>
#include <qxmlputget.h>

namespace Ui {
class addparties;
}

class addparties : public QDialog
{
    Q_OBJECT

//build Parties List
void AddRootParties(QString entity, QString fname, QString lname, QString designation, QString party, QString contact, QString present);
void GetDefaultPartyInfo();
public:
    explicit addparties(QWidget *parent = 0);
    ~addparties();
    
private:
    Ui::addparties *ui;
};

#endif // ADDPARTIES_H
