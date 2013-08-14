#ifndef ADDRELATEDCASE_H
#define ADDRELATEDCASE_H

#include <QDialog>

namespace Ui {
class addrelatedcase;
}

class addrelatedcase : public QDialog
{
    Q_OBJECT
    
public:
    explicit addrelatedcase(QWidget *parent = 0);
    ~addrelatedcase();
    
private:
    Ui::addrelatedcase *ui;
};

#endif // ADDRELATEDCASE_H
