#ifndef REISSUE_H
#define REISSUE_H

#include <QDialog>

namespace Ui {
class Reissue;
}

class Reissue : public QDialog
{
    Q_OBJECT
    
public:
    explicit Reissue(QWidget *parent = 0);
    ~Reissue();
    
private:
    Ui::Reissue *ui;
};

#endif // REISSUE_H
