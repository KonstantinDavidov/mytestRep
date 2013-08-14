#ifndef CASESAVE_H
#define CASESAVE_H

#include <QDialog>

namespace Ui {
class casesave;
}

class casesave : public QDialog
{
    Q_OBJECT
    
void LoadSaveFile();

public:
    explicit casesave(QWidget *parent = 0);
    ~casesave();

void setCase(QString caseId);
    
private slots:
    void on_toolButton_saveRecord_clicked();

private:
    Ui::casesave *ui;
};

#endif // CASESAVE_H
