module Service

open Adapter

    type Service = 
        abstract member execute : unit