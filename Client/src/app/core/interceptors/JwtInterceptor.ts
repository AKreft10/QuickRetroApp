import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let sessionObject = sessionStorage.getItem('jwt');
        console.log(sessionObject);
        if(sessionObject)
            {
                var sessionObj = JSON.parse(sessionObject);
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${sessionObj.token}`
                }
            });
        }

            return next.handle(req);
    }

}