export interface Result<T = unknown> {
    success: boolean;
    message: string;
    content: T;
}