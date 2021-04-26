module Domain

open Move

type Repository = 
    abstract member FindAll : unit -> Shipper array
    abstract member Save : Shipper -> unit