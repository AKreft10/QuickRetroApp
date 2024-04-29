export interface RetroBoardColumnItem {
    id: string;
    textContent: string;
  }
  
  export interface RetroBoardColumn {
    id: string;
    name: string;
    items: RetroBoardColumnItem[];
  }
  
  export interface RetroBoard {
    id: string;
    name: string;
    columns: RetroBoardColumn[];
  }
  
  export interface RetrospectiveColumn {
    name: string;
    cards: string[];
    id: string | undefined;
  }
  
  export interface RetrospectiveBoard {
    columns: RetrospectiveColumn[];
  }