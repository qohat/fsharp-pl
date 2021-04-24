namespace Main

type Effect<'result> =
    | Log of string * (unit -> Effect<'result>)
    | Result of 'result