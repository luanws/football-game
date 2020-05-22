[System.Serializable]
public class Fase {
    public int numero;
    private bool _desbloqueado = false;
    public bool desbloqueado {
        get { return _desbloqueado; }
    }
    public Fase(int numero, bool desbloqueado) {
        this.numero = numero;
        this._desbloqueado = desbloqueado;
    }
    public void desbloquear() {
        _desbloqueado = true;
    }
}